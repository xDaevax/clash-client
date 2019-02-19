namespace ClashClient.Common.Caching {
    /// <summary>
    /// Enumeration that represents the options for cache configuration in a general way to abstract away hard-coded cache duration and policy.
    /// </summary>
    public enum CachePreference : int {
        /// <summary>
        /// The default cache length, neither short or long (absolute).
        /// </summary>
        Default = 0,

        /// <summary>
        /// Used for short-lived objects, typically related to a transaction.
        /// </summary>
        ShortLived = 1,

        /// <summary>
        /// Used for short-lived objects on a sliding expiration, typically related to a transaction.
        /// </summary>
        ShortLivedSliding = 2,

        /// <summary>
        /// Longer than normal.  Could be bumped out of memory for highier priority items.
        /// </summary>
        Extended = 3,

        /// <summary>
        /// Longer than normal with sliding expiration.  Could be bumped out of memory for highier priority items.
        /// </summary>
        ExtendedSliding = 4,

        /// <summary>
        /// A long-lived duration, generally perferred over more temporary preferences.
        /// </summary>
        LongTerm = 5,

        /// <summary>
        /// A long-lived duration with sliding expiration, generally perferred over more temporary preferences.
        /// </summary>
        LongTermSliding = 6,

        /// <summary>
        /// Will never leave the cache during normal operation.
        /// </summary>
        Permanent = 7
    } // end enumeration CachePreference
} // end namespace
