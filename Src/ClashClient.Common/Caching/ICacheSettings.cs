namespace ClashClient.Common.Caching {
    /// <summary>
    /// Interface used to expose functionality for types that interact with custom cache durations and preference settings.
    /// </summary>
    public interface ICacheSettings {
        #region --Functions--

        /// <summary>
        /// Loads the preference with details that can be used to add items to cache based on the given <paramref name="preference"/>.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreference"/> to load.</param>
        /// <returns>A new instance of a type dervied from the <see cref="ICachePreferenceElement"/> type.</returns>
        ICachePreferenceElement LoadPreference(CachePreference preference);

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets a value indicating whether caching is enabled application-wide.
        /// </summary>
        bool CachingEnabled { get; }

        #endregion
    } // end interface ICacheSettings
} // end namespace
