using System;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents the response from a request for clan member information.
    /// </summary>
    [Serializable]
    public class ClanMembersResponse : SearchResponse<ClanMemberResult> {
        #region --Fields--

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanMembersResponse"/> class.
        /// </summary>
        public ClanMembersResponse() : base() {
        } // end default constructor

        #endregion

        #region --Properties--

        #endregion
    } // end class ClanMembersResponse
} // end namespace
