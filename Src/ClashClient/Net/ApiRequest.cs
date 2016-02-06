using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to provide data needed to build a clash of clans API request.
    /// </summary>
    public class ApiRequest {
        #region --Instance Variables--

        private string _apiToken;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiRequest"/> class.
        /// </summary>
        public ApiRequest() {
            this._apiToken = string.Empty;
        } // end default constructor

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

        #endregion
    } // end class ApiRequest
} // end namespace
