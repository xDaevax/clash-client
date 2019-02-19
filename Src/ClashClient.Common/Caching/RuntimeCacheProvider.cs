using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using log4net;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type that leverages the in-memory caching to store data in memory.  Implements the <see cref="ICacheProvider"/> type.
    /// </summary>
    public class RuntimeCacheProvider : ICacheProvider {
        private static ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region --Fields--

        private readonly MemoryCache _cacheStore;
        private readonly object _cacheLock;
        private readonly ICacheSettings _cacheSettings;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="RuntimeCacheProvider"/> class.
        /// </summary>
        /// <param name="cacheSettings">The <see cref="ICacheSettings"/> instance used to load specialized cache configuration.</param>
        public RuntimeCacheProvider(ICacheSettings cacheSettings) {
            this._cacheLock = new object();
            this._cacheStore = MemoryCache.Default;
            this._cacheSettings = cacheSettings;
        } // end constructor

        #endregion

        #region --Methods--

        /// <summary>
        /// Attempts to remove an entry (if found) matching the given <paramref name="name"/> from the cache.
        /// </summary>
        /// <param name="name">The name or key of the item to remove from cache.</param>
        public virtual void Remove(string name) {
            Log.DebugFormat("Attempting to remove {0} from the cache.", name);

            if (!string.IsNullOrWhiteSpace(name)) {
                if (this.CacheSettings.CachingEnabled) {
                    if (this.CacheStore.Contains(name)) {
                        lock (this._cacheLock) {
                            if (this.CacheStore.Contains(name)) {
                                this.CacheStore.Remove(name, CacheEntryRemovedReason.Removed);
                                Log.DebugFormat("{0} was removed from the cache.", name);
                            } else {
                                Log.DebugFormat("{0} was not removed because it could no longer be found.", name);
                            }
                        }
                    } else {
                        Log.DebugFormat("{0} was not found in cache.", name);
                    }
                } else {
                    Log.DebugFormat("Skipped removing entry {0} from cache because caching is disabled.", name);
                }
            } else {
                Log.InfoFormat("The name {0}, could not be removed from cache because it was not present in the cache.", name);
            }
        } // end method Remove

        /// <summary>
        /// Sets the given <paramref name="entry"/> in cache for the specified <paramref name="name"/>.  If the entry already exists, it will be overwritten.
        /// </summary>
        /// <typeparam name="TModel">The type of object being stored in cache.</typeparam>
        /// <param name="name">The unique name used to store this entry.</param>
        /// <param name="entry">The data to store.</param>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="name"/> is not specified.</exception>
        public void Set<TModel>(string name, CacheEntry<TModel> entry) where TModel : class {
            if (this.CacheSettings.CachingEnabled) {
                if (string.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentNullException(nameof(name), "No cache name provided.");
                }

                CacheItemPolicy policy;
                ICachePreferenceElement preferenceSetting = this.LoadPreferenceSetting(entry.CachePreference);
                switch (entry.CachePreference) {
                    case CachePreference.ShortLivedSliding:
                    case CachePreference.ExtendedSliding:
                    case CachePreference.LongTermSliding:
                        policy = new CacheItemPolicy() {
                            SlidingExpiration = TimeSpan.FromMinutes(preferenceSetting.Duration),
                            Priority = CacheItemPriority.Default
                        };
                        break;
                    case CachePreference.Default:
                    case CachePreference.ShortLived:
                    case CachePreference.Extended:
                    case CachePreference.LongTerm:
                        policy = new CacheItemPolicy() {
                            AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(preferenceSetting.Duration),
                            Priority = CacheItemPriority.Default
                        };
                        break;
                    case CachePreference.Permanent:
                        policy = new CacheItemPolicy() {
                            SlidingExpiration = TimeSpan.Zero,
                            Priority = CacheItemPriority.NotRemovable
                        };
                        break;
                    default:
                        policy = new CacheItemPolicy() {
                            SlidingExpiration = TimeSpan.FromMinutes(30),
                            Priority = CacheItemPriority.Default
                        };
                        break;
                }

                Log.DebugFormat("Attempting to update the cache for {0} with a {1} policy.", name, policy.Priority == CacheItemPriority.NotRemovable ? "Permanent" : "Sliding Expiration");

                lock (this._cacheLock) {
                    this.CacheStore.Set(new CacheItem(name, entry), policy);
                }
            } else {
                Log.DebugFormat("Skipped writing cache entry.  Caching is disabled in the configuration.");
            }
        } // end method Set

        #endregion

        #region --Functions--

        /// <summary>
        /// Attempts to load the given <paramref name="preference"/> from the custom cache settings.  If it is not defined, this method returns null.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreference"/> to look-up.</param>
        /// <returns>The matching <see cref="ICachePreferenceElement"/> in config (if defined);  null otherwise.</returns>
        public virtual ICachePreferenceElement LoadPreferenceSetting(CachePreference preference) {
            Log.DebugFormat("Loading cache preference settings for the {0} preference.", preference.ToString());
            var setting = this.CacheSettings.LoadPreference(preference);
            ICachePreferenceElement returnValue = null;

            if (setting == null) {
                Log.WarnFormat("No configuration present for preference {0}.", preference.ToString());
            } else {
                returnValue = setting;
            }

            return returnValue;
        } // end function LoadPreferenceSetting

        /// <summary>
        /// Attempted to load some details regarding cached items using reflection to interrogate the memory cache.  This method is not efficient and should be used only when necessary.
        /// </summary>
        /// <param name="nameFilters">The set of names that should be loaded from cache (if any).</param>
        /// <returns>A new <see cref="CachedItem"/> array or null if no <paramref name="nameFilters"/> are provided.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We want a catch all here to log the information but not cause the application to fail.")]
        public virtual CachedItem[] GetCacheItemInfo(IEnumerable<string> nameFilters) {
            if (nameFilters == null || !nameFilters.Any()) {
                return null;
            }

            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            FieldInfo storeField = typeof(MemoryCache).GetField("_storeRefs", bindFlags);
            var info = new List<CachedItem>();

            object[] cacheStores = null;

            try {
                cacheStores = (object[])storeField.GetValue(this.CacheStore);
            } catch (Exception ex) {
                Log.Warn($"Unable to reflect over the cache stores to load detailed cache information.  It's possible that an update to the .NET Framework has changed the referenced field name. Exception: {ex.Message}.\r\nStack Trace:\r\n{ex.StackTrace}");
            }

            if (cacheStores != null && cacheStores.Any()) {
                foreach (object cacheStore in cacheStores) {
                    try {
                        Type cacheStoreType = cacheStore.GetType();

                        PropertyInfo targetType = cacheStoreType.GetProperty("Target", bindFlags);

                        var storeTarget = targetType?.GetValue(cacheStore);

                        FieldInfo lockField = targetType?.GetValue(cacheStore).GetType().GetField("_entriesLock", bindFlags);

                        object lockObj = lockField?.GetValue(storeTarget);
                        if (lockObj != null) {
                            lock (lockObj) {

                                FieldInfo entriesField = targetType.GetValue(cacheStore).GetType().GetField("_entries", bindFlags);
                                var entriesCollection = (Hashtable)entriesField.GetValue(storeTarget);

                                foreach (DictionaryEntry cacheItemEntry in entriesCollection) {
                                    Type cacheItemValueType = cacheItemEntry.Value.GetType();

                                    string key = (string)cacheItemEntry.Key.GetType().GetProperty("Key", bindFlags).GetValue(cacheItemEntry.Key);
                                    if (nameFilters.Any(t => string.Equals(key, t, StringComparison.OrdinalIgnoreCase))) {
                                        Log.Info($"Attempting to load cache information for the key: {key}.");
                                        PropertyInfo value = cacheItemValueType.GetProperty("Value", bindFlags);
                                        PropertyInfo utcAbsoluteExpiry = cacheItemValueType.GetProperty("UtcAbsExp", bindFlags);
                                        var valueInstance = value.GetValue(cacheItemEntry.Value);
                                        CachePreference preference = CachePreference.Default;
                                        if (valueInstance != null && valueInstance.GetType().GetProperty("CachePreference") != null) {
                                            preference = (CachePreference)valueInstance.GetType().GetProperty("CachePreference").GetValue(valueInstance);
                                        }

                                        var ci = new CachedItem() {
                                            CacheName = key,
                                            Expiration = new DateTimeOffset((DateTime)utcAbsoluteExpiry.GetValue(cacheItemEntry.Value)),
                                            IsCached = true,
                                            CurrentPreference = preference
                                        };

                                        info.Add(ci);
                                    }
                                }

                            }
                        } else {
                            Log.Warn("Could not find the lock object field on the cache store.");
                        }
                    } catch (Exception ex) {
                        Log.Error($"Unable to load details for the cache store.", ex);
                    }
                }
            }

            return info.ToArray();
        } // end function GetCacheItemInfo

        /// <summary>
        /// Checks the memory available to the cache for storage.
        /// </summary>
        /// <returns>The size (in bytes) of the memory available to the cache.</returns>
        public virtual long MaximumSize() {
            return this.CacheStore.CacheMemoryLimit;
        } // end function MaximumSize

        /// <summary>
        /// Attempts to load an item from cache matching the given <paramref name="name"/>.  This method will always return an empty <see cref="CacheEntry{TCachedItem}"/> if caching is disabled.
        /// </summary>
        /// <typeparam name="TModel">The type of data stored in cache.</typeparam>
        /// <param name="name">The name of the item in cache.</param>
        /// <returns>A <see cref="CacheEntry{TCachedItem}"/> instance representing the cached data; or null or an empty instance if the cache query was a miss.</returns>
        public virtual CacheEntry<TModel> Read<TModel>(string name) where TModel : class {
            CacheEntry<TModel> returnValue = null;
            if (this.CacheSettings.CachingEnabled) {
                if (!string.IsNullOrWhiteSpace(name)) {
                    Log.DebugFormat("Attempting to read cache entry {0} from the cache.", name);
                    if (this.CacheStore.Contains(name)) {
                        lock (this._cacheLock) {
                            if (this.CacheStore.Contains(name)) {
                                returnValue = Convert.ChangeType(this.CacheStore.Get(name), typeof(CacheEntry<TModel>)) as CacheEntry<TModel>;
                            }
                        }
                    }
                }

                if (returnValue == null) {
                    returnValue = new CacheEntry<TModel>(null as TModel);
                }

                if (returnValue.CacheHit()) {
                    Log.DebugFormat("{0} was loaded from cache.", name);
                } else {
                    Log.DebugFormat("{0} was not found in cache.", name);
                }
            } else {
                Log.DebugFormat("Skipped loading data from cache. Caching is diabled in the configuration.");
            }

            return returnValue;
        } // end function Read

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets the in-memory cache.
        /// </summary>
        protected MemoryCache CacheStore {
            get => this._cacheStore;
        } // end property CacheStore

        /// <summary>
        /// Gets the injected <see cref="ICacheSettings"/> instance used to load custom cache configuration settings.
        /// </summary>
        protected ICacheSettings CacheSettings {
            get => this._cacheSettings;
        } // end property CacheSettings

        #endregion
    } // end class RuntimeCacheProvider
} // end namespace
