namespace ClashClient.Common.Caching {
    /// <summary>
    /// Interface that abstracts away the implementation detail of custom configuration for caching and allows the custom cache to be stored according to the needs of the implementing code.  It also simplifies testing.
    /// </summary>
    public interface ICachePreferenceElement {
        #region --Properties--

        /// <summary>
        /// Gets or sets the actual length of time in minutes for this preference.
        /// </summary>
        int Duration { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CachePreference"/> setting.
        /// </summary>
        CachePreference Preference { get; set; }

        #endregion
    } // end interface ICachePreferenceElement
} // end namespace
