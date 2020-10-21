using ClashClient.Common.Extensions;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type that represents and wraps an item in cache.  Loading the data from the cache will perform a deep-copy of the item.
    /// </summary>
    /// <typeparam name="TCachedItem"></typeparam>
    public class CacheEntry<TCachedItem> where TCachedItem : class {
        #region --Fields--

        private CachePreference _cachePreference;
        private readonly TCachedItem _data;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry{TCachedItem}"/> class.
        /// </summary>
        public CacheEntry() {
            this._data = default(TCachedItem);
        } // end default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheEntry{TCachedItem}"/> class.
        /// </summary>
        /// <param name="data">The <typeparamref name="TCachedItem"/> instancce being stored.</param>
        public CacheEntry(TCachedItem data) : this() {
            this._data = data;
        } // end overloaded constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Determines whether or not the attempt to load from cache was successful.
        /// </summary>
        /// <returns>true if data was found in cache; false otherwise</returns>
        public virtual bool CacheHit() {
            return this.Data != null;
        } // end function CacheHit

        /// <summary>
        /// Performs a deep-copy of the data if found in cache or a default value for the given <typeparamref name="TCachedItem"/> if no cache data was found.
        /// </summary>
        /// <returns>A deep-copy of the <typeparamref name="TCachedItem"/> found in cache.</returns>
        public virtual TCachedItem LoadCachedData() {
            return this.Data != null ? this.Data.Copy() : default(TCachedItem);
        } // end function LoadCachedData

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the <see cref="CachePreference"/> on cache duration.
        /// </summary>
        public virtual CachePreference CachePreference {
            get => this._cachePreference;
            set => this._cachePreference = value;
        } // end property CachePreference

        /// <summary>
        /// Gets the underlying cached data.  Not exposed to force usage of the <see cref="LoadCachedData"/> method and the <see cref="CacheHit()"/> method.
        /// </summary>
        protected TCachedItem Data => this._data; // end property Data

        #endregion
    } // end class CacheEntry
} // end namespace
