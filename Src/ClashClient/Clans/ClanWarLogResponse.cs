using System;

namespace ClashClient.Clans {
    /// <summary>
    /// Type the represents the contents of a clan's war log.
    /// </summary>
    [Serializable]
    public class ClanWarLogResponse : SearchResponse<ClanWarEntry> {
        #region --Fields--

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanWarLogResponse"/> class.
        /// </summary>
        public ClanWarLogResponse() : base() {
        } // end default constructor

        #endregion

        #region --Properties--

        #endregion
    } // end class ClanWarLogResponse
} // end namespace
