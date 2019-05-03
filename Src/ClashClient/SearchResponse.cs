using System;
using System.Collections.ObjectModel;
using ClashClient.Net;
using Newtonsoft.Json;

namespace ClashClient {
    /// <summary>
    /// Base type for API responses that have multiple results / paging.
    /// </summary>
    [Serializable]
    public abstract class SearchResponse<TResult> where TResult : class {
        #region --Fields--

        private Collection<TResult> _items;
        private Pager _pager;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResponse{TResult}"/> class.
        /// </summary>
        protected SearchResponse() {
            this._items = new Collection<TResult>();
            this._pager = new Pager();
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the items returned by the search.
        /// </summary>
        [JsonProperty("items")]
        public Collection<TResult> Items {
            get => this._items;
            set => this._items = value ?? new Collection<TResult>();
        } // end property Items

        /// <summary>
        /// Gets or sets the pager for the search results to aid in sequential queries.
        /// </summary>
        [JsonProperty("paging")]
        public Pager Pager {
            get => this._pager;
            set => this._pager = value ?? new Pager();
        } // end property Pager

        #endregion
    } // end class SearchResponse
} // end namespace
