using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents the response from a request for clan member information.
    /// </summary>
    [Serializable]
    public class ClanMembersResponse {
        #region --Fields--

        private List<ClanMemberResult> _members;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanMembersResponse"/> class.
        /// </summary>
        public ClanMembersResponse() {
            this._members = new List<ClanMemberResult>();
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the set of members in the clan.
        /// </summary>
        [JsonProperty("items")]
        public virtual IEnumerable<ClanMemberResult> Members {
            get => this._members.AsEnumerable();
            set => this._members = value.ToList() ?? new List<ClanMemberResult>();
        } // end property Members

        #endregion
    } // end class ClanMembersResponse
} // end namespace
