using System;
using System.Web;
using ClashClient.Net;

namespace ClashClient.Clans {
    /// <summary>
    /// A search request type used to load clan war log information for a specific clan.
    /// </summary>
    [Serializable]
    public class ClanWarLogRequest : ApiCollectionRequest {
        #region --Fields--

        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanWarLogRequest"/> class.
        /// </summary>
        public ClanWarLogRequest() : base() {
            this._tag = string.Empty;
            this.Endpoint = ClashEndpoints.ClanWarLog;
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

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the clan tag of the clan whose war log info is to be loaded.
        /// </summary>
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class ClanWarLogRequest
} // end namespace
