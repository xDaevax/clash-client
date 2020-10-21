using System;
using System.Collections.Generic;
using System.Linq;
using ClashClient.Annotations;
using ClashClient.Net;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Request type that contains the potential parameters used to perform a clan search request.
    /// </summary>
    [Serializable]
    public class ClanSearchRequest : ApiCollectionRequest {
        #region --Instance Variables--

        private string _clanName;
        private int _locationId;
        private int _maximumMembers;
        private int _minimumClanLevel;
        private int _minimumClanPoints;
        private int _minimumMembers;
        private WarFrequency? _warFrequency;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchRequest"/> class.
        /// </summary>
        public ClanSearchRequest() {
            this._clanName = string.Empty;
            this._locationId = -1;
            this._maximumMembers = -1;
            this._minimumClanLevel = -1;
            this._minimumClanPoints = -1;
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
            Dictionary<string, object> baseParameters = base.QueryParametersToInclude();
            if (baseParameters.Any()) {
                foreach (var key in baseParameters.Keys) {
                    filteredParameters.Add(key, baseParameters[key]);
                }
            }

            if (!string.IsNullOrWhiteSpace(this.ClanName)) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.ClanName))), this.ClanName);
            }

            if (this.WarFrequency != null) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.WarFrequency))), this.WarFrequency.Value);
            }

            if (this.MaximumMembers >= 0) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.MaximumMembers))), this.MaximumMembers);
            }

            if (this.MinimumMembers >= 0) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.MinimumMembers))), this.MinimumMembers);
            }

            if (this.LocationId >= 0) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.LocationId))), this.LocationId);
            }

            if (this.MinimumClanPoints >= 0) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.MinimumClanPoints))), this.MinimumClanPoints);
            }

            if (this.MinimumClanLevel >= 0) {
                filteredParameters.Add(JsonAnnotationHelper.GetJsonNameFromProperty(this.GetType().GetProperty(nameof(this.MinimumClanLevel))), this.MinimumClanLevel);
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
            get => this._clanName; set => this._clanName = value;
        } // end property ClanName

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
        /// Gets or sets the filter that excludes clans below a certain level.
        /// </summary>
        [JsonProperty("minClanLevel")]
        public virtual int MinimumClanLevel {
            get => this._minimumClanLevel;
            set => this._minimumClanLevel = value;
        } // end property MinimumClanLevel

        /// <summary>
        /// Gets or sets the minimum point filter for clans returned in the results.
        /// </summary>
        [JsonProperty("minClanPoints")]
        public virtual int MinimumClanPoints {
            get => this._minimumClanPoints;
            set => this._minimumClanPoints = value;
        } // end property MinimumClanPoints

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
