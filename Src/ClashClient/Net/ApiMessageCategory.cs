using System;

namespace ClashClient.Net {
    /// <summary>
    /// Enumeration that identifies different levels / categories for messages returned from an API.
    /// </summary>
    [Serializable]
    public enum ApiMessageCategory : int {
        /// <summary>
        /// The default option.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The message is diagnostic or designed for consuming code, not end-users.
        /// </summary>
        Diagnostic = 1,

        /// <summary>
        /// The message is informational.
        /// </summary>
        Information = 2,

        /// <summary>
        /// The message indicates a problem, either with the request, processing, or response but some data may have come back.
        /// </summary>
        Problem = 3,

        /// <summary>
        /// The message describes a complete call failure.
        /// </summary>
        Failure = 4
    } // end enumeration ApiMessageCategory
} // end namespace
