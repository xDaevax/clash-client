using System.Web;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to provide data needed to build a clash of clans API request.
    /// </summary>
    public abstract class ApiRequest {
        #region --Instance Variables--

        private string _apiToken;
        private string _method;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        public ApiRequest() {
            this._apiToken = string.Empty;
            this._method = string.Empty;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the name this request should use for caching purposes.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to parse parameters</param>
        /// <returns>A cache-key safe string to use for the name of this item if stored in cache.</returns>
        public virtual string ToCacheName(QueryStringFormatter formatter) {
            return HttpUtility.UrlDecode($"{this.Method}_{this.ParametersToUrlPath()}_{this.ParametersToQueryString(formatter)}").Replace(" ", "_");
        } // end function ToCacheName

        /// <summary>
        /// Converts the properties relevant to the request into their corresponding query-string name / value pairs.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to format property values for query string use.</param>
        /// <returns>A string formatted for a query-string in a URL.</returns>
        public virtual string ParametersToQueryString(QueryStringFormatter formatter) {
            return string.Empty;
        } // end function ParametersToQueryString

        /// <summary>
        /// Returns the set of parameters that need to be included in the URL (not as part of the query string).
        /// </summary>
        /// <returns>A string (with leading "/") for the url arguments.</returns>
        public virtual string ParametersToUrlPath() {
            return string.Empty;
        } // end function ParametersToUrlPath

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
        public virtual string Method {
            get {
                return this._method;
            } set {
                this._method = value;
            }
        } // end property Method

        #endregion
    } // end class ApiRequest
} // end namespace
