using System.Web;
using ClashClient.Net;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to request information about the members of a clan.
    /// </summary>
    public class ClanMembersRequest : ApiCollectionRequest {
        #region --Fields--

        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanMembersRequest"/> class.
        /// </summary>
        public ClanMembersRequest() : base() {
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

        #endregion

        #region --Properties--

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
