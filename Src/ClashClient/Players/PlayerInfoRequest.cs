using System;
using System.Web;
using ClashClient.Net;

namespace ClashClient.Players {
    /// <summary>
    /// Type used to request detailed player information from the API.
    /// </summary>
    [Serializable]
    public class PlayerInfoRequest : ApiRequest {
        #region --Fields--

        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerInfoRequest"/> class.
        /// </summary>
        public PlayerInfoRequest() : base() {
            this._tag = string.Empty;
            this.Endpoint = ClashEndpoints.PlayerDetail;
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
        /// Gets or sets the tag of the player.
        /// </summary>
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class PlayerInfoRequest
} // end namespace
