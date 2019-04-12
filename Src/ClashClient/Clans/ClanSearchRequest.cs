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
        private int _limit;
        private int _locationId;
        private int _maximumMembers;
        private int _minimumMembers;
        private WarFrequency? _warFrequency;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchRequest"/> class.
        /// </summary>
        public ClanSearchRequest() {
            this._clanName = string.Empty;
            this._limit = -1;
            this._locationId = -1;
            this._maximumMembers = -1;
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

            if (this.MaximumMembers >= 0) {
                if (needsConcatenated) {
                    sb.Append("&");
                }

                var maxMemberPair = formatter.Format("maxMembers", this.MaximumMembers, false);

                sb.Append($"{maxMemberPair.Key}={maxMemberPair.Value}");
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

            if (this.LocationId >= 0) {
                if (needsConcatenated) {
                    sb.Append("&");
                }

                var locationIdPair = formatter.Format("locationId", this.LocationId, false);

                sb.Append($"{locationIdPair.Key}={locationIdPair.Value}");
                needsConcatenated = true;
            }

            if (this.Limit >= 0) {
                if (needsConcatenated) {
                    sb.Append("&");
                }

                var limitPair = formatter.Format("limit", this.Limit, false);

                sb.Append($"{limitPair.Key}={limitPair.Value}");
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
        /// Gets or sets the maximum number of results to return.
        /// </summary>
        [JsonProperty("limit")]
        public virtual int Limit {
            get => this._limit;
            set => this._limit = value;
        } // end property Limit

        /// <summary>
        /// Gets or sets the location id search filter (-1 if not specified the argument will not be passed).
        /// </summary>
        [JsonProperty("locationId")]
        public virtual int LocationId {
            get => this._locationId;
            set => this._locationId = value;
        } // end property LocationId

        /// <summary>
        /// Gets or sets the maximum number of members for the resulting clans to have.
        /// </summary>
        [JsonProperty("maxMembers")]
        public virtual int MaximumMembers {
            get => this._maximumMembers;
            set => this._maximumMembers = value;
        } // end property MaximumMembers

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
