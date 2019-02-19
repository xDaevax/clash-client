using System;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type that represents an individual item that can be cached.
    /// </summary>
    [Serializable]
    public class CachedItem {
        #region --Fields--

        private string _cacheName;
        private CachePreference _currentPreference;
        private bool _isCached;
        private DateTimeOffset? _expiration;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedItem"/> class.
        /// </summary>
        public CachedItem() {
            this._cacheName = string.Empty;
            this._currentPreference = CachePreference.Default;
            this._isCached = false;
            this._expiration = null;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the name of the cache entry.
        /// </summary>
        public virtual string CacheName {
            get => this._cacheName;
            set => this._cacheName = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property CacheName

        /// <summary>
        /// Gets or sets the <see cref="CachePreference"/> for the cache entry.
        /// </summary>
        public virtual CachePreference CurrentPreference {
            get => this._currentPreference;
            set => this._currentPreference = value;
        } // end property CurrentPreference

        /// <summary>
        /// Gets or sets a value indicating whether the item is currently in cache.
        /// </summary>
        public virtual bool IsCached {
            get => this._isCached;
            set => this._isCached = value;
        } // end property IsCached

        /// <summary>
        /// Gets or sets the date / time this cache item will expire (if any).
        /// </summary>
        public DateTimeOffset? Expiration {
            get => this._expiration;
            set => this._expiration = value;
        } // end property Expiration

        #endregion
    } // end class CachedItem
} // end namespace
