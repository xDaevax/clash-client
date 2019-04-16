using System;
using System.Collections.Generic;
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
            this.Endpoint = ClashEndpoints.ClanSearch;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the filtered set of parameters that should be included in the query.
        /// </summary>
        /// <returns>A dictionary of key / value pairs with the data to include in the query string.</returns>
        public override Dictionary<string, object> QueryParametersToInclude() {
            var filteredParameters = new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(this.ClanName)) {
                filteredParameters.Add("name", this.ClanName);
            }

            if (this.WarFrequency != null) {
                filteredParameters.Add("warFrquency", this.WarFrequency.Value);
            }

            if (this.MaximumMembers >= 0) {
                filteredParameters.Add("maxMembers", this.MaximumMembers);
            }

            if (this.MinimumMembers >= 0) {
                filteredParameters.Add("minMembers", this.MinimumMembers);
            }

            if (this.LocationId >= 0) {
                filteredParameters.Add("locationId", this.LocationId);
            }

            if (this.Limit >= 0) {
                filteredParameters.Add("limit", this.Limit);
            }

            return filteredParameters;
        } // end function QueryParametersToInclude

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
