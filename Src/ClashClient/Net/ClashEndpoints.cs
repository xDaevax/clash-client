namespace ClashClient.Net {
    /// <summary>
    /// Static type that exposes strongly-typed names for the clash of clans API URL endpoints to avoid use of magic strings.
    /// </summary>
    public static class ClashEndpoints {
        #region --Endpoints--

        /// <summary>
        /// The clan search endpoint.
        /// </summary>
        public const string ClanSearch = "clans";

        /// <summary>
        /// The clan detail endpoint in the form of clans/{tag}.
        /// </summary>
        public const string ClanDetail = "clans/{0}";

        /// <summary>
        /// The summary information about the members of the clan in the form of clans/{tag}/members.
        /// </summary>
        public const string ClanMembers = "clans/{0}/members";


        #endregion
    } // end class ClashEndpoints
} // end namespace
