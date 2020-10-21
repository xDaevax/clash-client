using System;
using System.Collections.Generic;
using ClashClient.Annotations;
using Newtonsoft.Json;

namespace ClashClient.Net {
    /// <summary>
    /// A base type for API calls that return collection information.  This type exposes some fields common to all similar requests.
    /// </summary>
    [Serializable]
    public abstract class ApiCollectionRequest : ApiRequest {
        #region --Fields--

        private string _after;
        private string _before;
        private int? _limit;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCollectionRequest"/> class.
        /// </summary>
        protected ApiCollectionRequest() : base() {
            this._after = string.Empty;
            this._before = string.Empty;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the filtered set of parameters that should be included in the query.
        /// </summary>
        /// <returns>A dictionary of key / value pairs with the data to include in the query string.</returns>
        public override Dictionary<string, object> QueryParametersToInclude() {
            Dictionary<string, object> returnValue = base.QueryParametersToInclude();
            if (this.Limit != null) {
                returnValue.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.Limit))), this.Limit.Value);
            }

            if (!string.IsNullOrWhiteSpace(this.Before) && !string.IsNullOrWhiteSpace(this.After)) {
                throw new ArgumentException("Either before or after must be specified, setting both is not allowed.");
            }

            if (!string.IsNullOrWhiteSpace(this.Before)) {
                returnValue.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.Before))), this.Before);
            }

            if (!string.IsNullOrWhiteSpace(this.After)) {
                returnValue.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.After))), this.After);
            }

            return returnValue;
        } // end function QueryParametersToInclude

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the marker to indicate where the search results should start (used in paged result sets).
        /// </summary>
        [JsonProperty("after")]
        public string After {
            get => this._after;
            set => this._after = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property After

        /// <summary>
        /// Gets or sets the marker that indicates where to stop when returning results form the search (used in paged result sets).
        /// </summary>
        [JsonProperty("before")]
        public string Before {
            get => this._before;
            set => this._before = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Before

        /// <summary>
        /// Gets or sets the maximum number of results to return from the API.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit {
            get => this._limit;
            set => this._limit = value;
        } // end property Limit

        #endregion
    } // end class ApiCollectionRequest
} // end namespace
