using System;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to store results of a set of clans found to match a clan search request.
    /// </summary>
    [Serializable]
    public class ClanSearchResponse : SearchResponse<ClanResult> {
        #region --Fields--

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchResponse"/> class.
        /// </summary>
        public ClanSearchResponse()
            : base() {
        } // end default constructor

        #endregion

        #region --Properties--

        #endregion
    } // end class ClanSearchResponse
} // end namespace
