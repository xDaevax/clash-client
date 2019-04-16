using System.Collections.Generic;
using System.Web;
using ClashClient.Net;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to request information about the members of a clan.
    /// </summary>
    public class ClanMembersRequest : ApiRequest {
        #region --Fields--

        private int _limit;
        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanMembersRequest"/> class.
        /// </summary>
        public ClanMembersRequest() : base() {
            this._limit = -1;
            this._tag = string.Empty;
            this.Endpoint = ClashEndpoints.ClanMembers;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the set of parameters that need to be included in the URL (not as part of the query string).
        /// </summary>
        /// <returns>A string (with leading "/") for the url arguments.</returns>
        public override string ParametersToUrlPath() {
            return string.Concat(string.Format(this.Endpoint, HttpUtility.UrlEncode(this.Tag)).Replace("//", "/"));
        } // end function ParametersToUrlPath

        /// <summary>
        /// Returns the filtered set of parameters that should be included in the query.
        /// </summary>
        /// <returns>A dictionary of key / value pairs with the data to include in the query string.</returns>
        public override Dictionary<string, object> QueryParametersToInclude() {
            var filteredParameters = new Dictionary<string, object>();

            if (this.Limit >= 0) {
                filteredParameters.Add("limit", this.Limit);
            }

            return filteredParameters;
        } // end function QueryParametersToInclude

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the maximum number of members that will be returned by the clash API.
        /// </summary>
        [JsonProperty("limit")]
        public virtual int Limit {
            get => this._limit;
            set => this._limit = value;
        } // end property Limit

        /// <summary>
        /// Gets or sets the clan tag to load members for.
        /// </summary>
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class ClanMembersRequest
} // end namespace
