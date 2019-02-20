using System;
using System.Collections.ObjectModel;
using ClashClient.Players;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents a more detailed set of information about an individual clan.
    /// </summary>
    [Serializable]
    public class DetailedClanResult : ClanResult {
        #region --Fields--

        private string _description;
        private Collection<PlayerSummary> _memberList;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedClanResult"/> class.
        /// </summary>
        public DetailedClanResult() : base() {
            this._description = string.Empty;
            this._memberList = new Collection<PlayerSummary>();
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the clan description.
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description {
            get => this._description;
            set => this._description = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Description

        /// <summary>
        /// Gets or sets a collection of <see cref="PlayerSummary"/> instances for all the members of the clan.
        /// </summary>
        [JsonProperty("memberList")]
        public virtual Collection<PlayerSummary> MemberList {
            get => this._memberList;
            set => this._memberList = value ?? new Collection<PlayerSummary>();
        } // end property MemberList

        #endregion
    } // end class DetailedClanResult
} // end namespace
