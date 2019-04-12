namespace ClashClient.Configuration {
    /// <summary>
    /// Class that exposes all of the "magic" configuration keys and strings in one place.
    /// </summary>
    internal static class ConfigurationKeys {
        #region --Keys--

        /// <summary>
        /// Returns the key name for the configuration key that refers to the version of the clash-of-clans API.
        /// Use this configuration key to load the value that controls which version of the API to call.
        /// </summary>
        /// <returns>ApiVersion</returns>
        internal const string ApiVersionKey = "ApiVersion";

        /// <summary>
        /// Returns the key name for the configuration key that refers to the base clash of clans URL.
        /// In the configuration, you can specify an alternate URL from the actual clash API to
        /// simplify testing or perform isolated tests in an offline environment.
        /// </summary>
        /// <returns>ClashAPI</returns>
        internal const string BaseApiUrlKey = "ClashAPI";

        /// <summary>
        /// Returns the key name for the configuration key that refers to the individual developer token used to authenticate
        /// against the clash of clans URL.
        /// </summary>
        /// <returns>ApiToken</returns>
        internal const string ApiTokenKey = "ApiToken";

        #endregion
    } // end class ConfigurationKeys
} // end namespace
