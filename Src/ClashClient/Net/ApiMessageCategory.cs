using System;

namespace ClashClient.Net {
    /// <summary>
    /// Enumeration type used to represent broad "categories" for returned messages.
    /// </summary>
    [Serializable]
    public enum ApiMessageCategory : int {
        /// <summary>
        /// No category is present, specified, or communicated.  Primarily this is used as a default value only.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// This message is primarily for diagnostics / tracing and can be disregarded.
        /// </summary>
        Diagnostic = 1,

        /// <summary>
        /// This message is informational and related to the operation but does not require elevation.
        /// </summary>
        Information = 2,

        /// <summary>
        /// This message requires elevation.
        /// </summary>
        RequiresElevation = 3,

        /// <summary>
        /// The content of the response this message is associated with is empty and this is expected behavior.
        /// </summary>
        NoData = 4,

        /// <summary>
        /// An error occurred, but was recoverable.
        /// </summary>
        Error = 5,

        /// <summary>
        /// Something unrecoverable occurred and should be elevated.
        /// </summary>
        Fault = 6,
    } // end enumeration MessageCategory
} // end namespace
