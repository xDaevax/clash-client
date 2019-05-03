using System;
using Newtonsoft.Json;

namespace ClashClient.Net {
    /// <summary>
    /// Type that represents the "cursor" object within a pager in an API response for a collection of data.
    /// </summary>
    [Serializable]
    public class PagingCursor {
        #region --Fields--

        private string _after;
        private string _before;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="PagingCursor"/> class.
        /// </summary>
        public PagingCursor() {
            this._after = string.Empty;
            this._before = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the "after" token or "marker" used to determine the starting point of the next query.  Can be empty if no additional pages are availabile.
        /// </summary>
        [JsonProperty("after")]
        public virtual string After {
            get => this._after;
            set => this._after = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property After

        /// <summary>
        /// Gets or sets the "before" token or "marker" used to determine the ending point of the current query.  Can be empty if no additional pages are available.
        /// </summary>
        [JsonProperty("before")]
        public virtual string Before {
            get => this._before;
            set => this._before = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Before

        #endregion
    } // end class PagingCursor
} // end namespace
