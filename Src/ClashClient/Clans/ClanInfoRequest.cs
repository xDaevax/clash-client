using System;
using System.Web;
using ClashClient.Net;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to request detailed information about a single clan.
    /// </summary>
    [Serializable]
    public class ClanInfoRequest : ApiRequest {
        #region --Fields--

        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanInfoRequest"/> class.
        /// </summary>
        public ClanInfoRequest() : base() {
            this._tag = string.Empty;
            this.Endpoint = ClashEndpoints.ClanDetail;
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
        /// Gets or sets the clan tag of the clan whose information is to be loaded.
        /// </summary>
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class ClanInfoRequest
} // end namespace
