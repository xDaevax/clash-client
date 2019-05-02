using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClashClient.Common.Extensions;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to provide data needed to build a clash of clans API request.
    /// </summary>
    public abstract class ApiRequest {
        #region --Instance Variables--

        private string _apiToken;
        private string _endpoint;
        private Dictionary<string, object> _queryParameters;
        private Dictionary<string, object> _urlParameters;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        public ApiRequest() {
            this._apiToken = string.Empty;
            this._endpoint = string.Empty;
            this._queryParameters = new Dictionary<string, object>();
            this._urlParameters = new Dictionary<string, object>();
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the name this request should use for caching purposes.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to parse parameters</param>
        /// <returns>A cache-key safe string to use for the name of this item if stored in cache.</returns>
        public virtual string ToCacheName(QueryStringFormatter formatter) {
            return HttpUtility.UrlDecode($"{this.ParametersToUrlPath()}_{this.ParametersToQueryString(formatter)}").Replace(" ", "_");
        } // end function ToCacheName

        /// <summary>
        /// Converts the properties relevant to the request into their corresponding query-string name / value pairs.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to format property values for query string use.</param>
        /// <returns>A string formatted for a query-string in a URL.</returns>
        public virtual string ParametersToQueryString(QueryStringFormatter formatter) {
            string returnValue = string.Empty;
            var parametersToInclude = this.QueryParametersToInclude();
            if (parametersToInclude.Any()) {
                var keyValuePairs = new List<string>();
                foreach(var key in parametersToInclude.Keys) { 
                    object pairValue = null;
                    if (parametersToInclude[key] != null && parametersToInclude[key].GetType().IsEnum) {
                        pairValue = EnumExtensions.ToEnumMemberAttributeValue(parametersToInclude[key] as Enum);
                    } else {
                        pairValue = parametersToInclude[key];
                    }

                    var formattedPair = formatter.Format(key, pairValue);
                    keyValuePairs.Add(string.Concat(formattedPair.Key, "=", formattedPair.Value));
                }

                if (keyValuePairs.Any()) {
                    returnValue = string.Concat("?", string.Join("&", keyValuePairs));
                }
            }

            return returnValue;
        } // end function ParametersToQueryString

        /// <summary>
        /// Returns the set of parameters that need to be included in the URL (not as part of the query string).
        /// </summary>
        /// <returns>A string (with leading "/") for the url arguments.</returns>
        public virtual string ParametersToUrlPath() {
            return this.Endpoint;
        } // end function ParametersToUrlPath

        /// <summary>
        /// When overridden by a derived type, performs logic to determine which query string parameters should be included.  This method is leveraged by the default <see cref="ParametersToQueryString(QueryStringFormatter)"/> implementation.
        /// </summary>
        /// <returns>A filtered list of query string parameters to include.</returns>
        public virtual Dictionary<string, object> QueryParametersToInclude() {
            return this.QueryParameters;
        } // end function QueryParametersToInclude

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the token needed for authentication against the API.
        /// </summary>
        public string ApiToken {
            get {
                return this._apiToken;
            } set {
                this._apiToken = value;
            }
        } // end property ApiToken

        /// <summary>
        /// Gets or sets the method to invoke on the API.
        /// </summary>
        public string Endpoint {
            get {
                return this._endpoint;
            } set {
                this._endpoint = value;
            }
        } // end property Endpoint

        /// <summary>
        /// Gets or sets the set of parameters to include in the query string (if any).
        /// </summary>
        public Dictionary<string, object> QueryParameters {
            get => this._queryParameters;
            set => this._queryParameters = value ?? new Dictionary<string, object>();
        } // end property QueryParameters

        /// <summary>
        /// Gets or sets the set of parameters to append to the query-string of the URL.
        /// </summary>
        public Dictionary<string, object> UrlParameters {
            get => this._urlParameters;
            set => this._urlParameters = value ?? new Dictionary<string, object>();
        } // end property UrlParameters

        #endregion
    } // end class ApiRequest
} // end namespace
