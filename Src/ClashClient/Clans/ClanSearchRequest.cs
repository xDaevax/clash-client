using ClashClient.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Clans {
    /// <summary>
    /// Request type that contains the potential parameters used to perform a clan search request.
    /// </summary>
    [Serializable]
    public class ClanSearchRequest : ApiRequest {
        #region --Instance Variables--

        private string _clanName;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchRequest"/> class.
        /// </summary>
        public ClanSearchRequest() {
            this._clanName = string.Empty;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns a formatted string for use as a query-string in a URL.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to format name / value pairs.</param>
        /// <returns>A formatted query-string.</returns>
        public override string ParametersToQueryString(QueryStringFormatter formatter) {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(this.ClanName)) {
                var namePair = formatter.Format("name", this.ClanName, true);
                sb.Append(string.Concat(namePair.Key, "=", namePair.Value));
            }

            return sb.ToString();
        } // end function ParametersToQueryString

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the name of the clan to search for.  This field is used as a partial match.
        /// </summary>
        [JsonProperty("name")]
        public virtual string ClanName {
            get {
                return this._clanName;
            } set {
                this._clanName = value;
            }
        } // end property ClanName

        #endregion
    } // end class ClanSearchRequest
} // end namespace
