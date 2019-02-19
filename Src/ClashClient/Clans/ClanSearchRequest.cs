using System;
using System.Text;
using ClashClient.Common.Extensions;
using ClashClient.Net;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Request type that contains the potential parameters used to perform a clan search request.
    /// </summary>
    [Serializable]
    public class ClanSearchRequest : ApiRequest {
        #region --Instance Variables--

        private string _clanName;
        private int _minimumMembers;
        private WarFrequency? _warFrequency;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchRequest"/> class.
        /// </summary>
        public ClanSearchRequest() {
            this._clanName = string.Empty;
            this._minimumMembers = -1;
            this._warFrequency = null;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns a formatted string for use as a query-string in a URL.
        /// </summary>
        /// <param name="formatter">The <see cref="QueryStringFormatter"/> instance used to format name / value pairs.</param>
        /// <returns>A formatted query-string.</returns>
        public override string ParametersToQueryString(QueryStringFormatter formatter) {
            var sb = new StringBuilder();
            bool needsConcatenated = false;
            if (!string.IsNullOrWhiteSpace(this.ClanName)) {
                var namePair = formatter.Format("name", this.ClanName, true);
                sb.Append(string.Concat(namePair.Key, "=", namePair.Value));
                needsConcatenated = true;
            }

            if (this.WarFrequency != null) {
                if (needsConcatenated) {
                    sb.Append("&");
                }

                var warPair = formatter.Format("warFrequency", this.WarFrequency.Value.ToEnumMemberAttributeValue(), false);

                sb.Append($"{warPair.Key}={warPair.Value}");
                needsConcatenated = true;
            }

            if (this.MinimumMembers >= 0) {
                if (needsConcatenated) {
                    sb.Append("&");
                }

                var minMemberPair = formatter.Format("minMembers", this.MinimumMembers, false);

                sb.Append($"{minMemberPair.Key}={minMemberPair.Value}");
                needsConcatenated = true;
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

        /// <summary>
        /// Gets or sets the minimum number of members for the resulting clans to have.
        /// </summary>
        [JsonProperty("minMembers")]
        public virtual int MinimumMembers {
            get => this._minimumMembers;
            set => this._minimumMembers = value;
        } // end property MinimumMembers

        /// <summary>
        /// Gets or sets a filter to use based on the clan's <see cref="Clans.WarFrequency"/> setting (if provided).
        /// </summary>
        [JsonProperty("warFrequency")]
        public virtual WarFrequency? WarFrequency {
            get => this._warFrequency;
            set => this._warFrequency = value;
        } // end property WarFrequence

        #endregion
    } // end class ClanSearchRequest
} // end namespace
