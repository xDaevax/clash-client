using System.Collections.Generic;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Interface that exposes functions for types that can provide data caching functionality.
    /// </summary>
    public interface ICacheProvider {
        #region --Methods--

        /// <summary>
        /// Attempts to remove an entry (if found) matching the given <paramref name="name"/> from the cache.
        /// </summary>
        /// <param name="name">The name or key of the item to remove from cache.</param>
        void Remove(string name);

        /// <summary>
        /// Sets the given <paramref name="entry"/> in cache with the specified <paramref name="name"/>.  If the entry already exists, it will be overwritten.
        /// </summary>
        /// <typeparam name="TModel">The type of data being cached.</typeparam>
        /// <param name="name">The name to store the item under in cache.</param>
        /// <param name="entry">The <see cref="CacheEntry{TCachedItem}"/> instance to store.</param>
        void Set<TModel>(string name, CacheEntry<TModel> entry) where TModel : class;

        #endregion

        #region --Functions--

        /// <summary>
        /// Attempted to load some details regarding cached items using reflection to interrogate the memory cache.  This method is not efficient and should be used only when necessary.
        /// </summary>
        /// <param name="nameFilters">The set of names that should be loaded from cache (if any).</param>
        /// <returns>A new <see cref="CachedItem"/> array or null if no <paramref name="nameFilters"/> are provided.</returns>
        CachedItem[] GetCacheItemInfo(IEnumerable<string> nameFilters);

        /// <summary>
        /// Checks the memory available to the cache for storage.
        /// </summary>
        /// <returns>The size (in bytes) of the memory available to the cache.</returns>
        long MaximumSize();

        /// <summary>
        /// Loads an item from cache matching the given <paramref name="name"/> and converts it to the given <typeparamref name="TModel"/> type.
        /// </summary>
        /// <typeparam name="TModel">The type of data stored in the cache.</typeparam>
        /// <param name="name">The name of the item in cache.</param>
        /// <returns>A new <see cref="CacheEntry{TCachedItem}"/> instance representing the data (or lack thereof) in cache.</returns>
        CacheEntry<TModel> Read<TModel>(string name) where TModel : class;

        #endregion
    } // end interface ICacheProvider
} // end namespace
