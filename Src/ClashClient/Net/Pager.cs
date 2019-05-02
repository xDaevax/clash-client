using System;
using Newtonsoft.Json;

namespace ClashClient.Net {
    /// <summary>
    /// Type that represents the "paging" value in API responses that return collections.
    /// </summary>
    [Serializable]
    public class Pager {
        #region --Fields--

        private PagingCursor _cursors;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="Pager"/> class.
        /// </summary>
        public Pager() {
            this._cursors = new PagingCursor();
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the <see cref="PagingCursor"/> instance with paging details for the results.
        /// </summary>
        [JsonProperty("cursors")]
        public virtual PagingCursor Cursors {
            get => this._cursors;
            set => this._cursors = value ?? new PagingCursor();
        } // end property Cursors

        #endregion
    } // end class Pager
} // end namespace
