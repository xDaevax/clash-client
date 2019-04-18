using System;
using ClashClient.Players;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents an individual clan member.
    /// </summary>
    [Serializable]
    public class ClanMemberResult {
        #region --Fields--

        private int _clanRank;
        private int _donations;
        private int _donationsReceived;
        private int _experienceLevel;
        private LeageResult _leage;
        private string _name;
        private string _role;
        private string _tag;
        private int _trophies;
        private int _versusTrophies;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanMemberResult"/> class.
        /// </summary>
        public ClanMemberResult() {
            this._clanRank = 0;
            this._donations = 0;
            this._donationsReceived = 0;
            this._experienceLevel = 0;
            this._leage = new LeageResult();
            this._name = string.Empty;
            this._role = string.Empty;
            this._tag = string.Empty;
            this._trophies = 0;
            this._versusTrophies = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the rank of the member within the clan.
        /// </summary>
        [JsonProperty("clanRank")]
        public virtual int ClanRank {
            get => this._clanRank;
            set => this._clanRank = value;
        } // end property ClanRank

        /// <summary>
        /// Gets or sets the number of donations this member has given.
        /// </summary>
        [JsonProperty("donations")]
        public virtual int Donations {
            get => this._donations;
            set => this._donations = value;
        } // end property Donations

        /// <summary>
        /// Gets or sets the number of donations this member has received.
        /// </summary>
        [JsonProperty("donationsReceived")]
        public virtual int DonationsReceived {
            get => this._donationsReceived;
            set => this._donationsReceived = value;
        } // end property Donations

        /// <summary>
        /// Gets or sets the experience level of this member.
        /// </summary>
        [JsonProperty("expLevel")]
        public virtual int ExperienceLevel {
            get => this._experienceLevel;
            set => this._experienceLevel = value;
        } // end property ExperienceLevel

        /// <summary>
        /// Gets or sets the leage this member is in.
        /// </summary>
        [JsonProperty("league")]
        public virtual LeageResult League {
            get => this._leage;
            set => this._leage = value ?? new LeageResult();
        } // end property League

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the role of this member within the clan.
        /// </summary>
        [JsonProperty("role")]
        public virtual string Role {
            get => this._role;
            set => this._role = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Role

        /// <summary>
        /// Gets or sets the tag that uniquely identifies the member.
        /// </summary>
        [JsonProperty("tag")]
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        /// <summary>
        /// Gets or sets the number of trophies this member has.
        /// </summary>
        [JsonProperty("trophies")]
        public virtual int Trophies {
            get => this._trophies;
            set => this._trophies = value;
        } // end property Trophies

        /// <summary>
        /// Gets or sets the number of versus battle trophies this member has.
        /// </summary>
        [JsonProperty("versusTrophies")]
        public virtual int VersusTrophies {
            get => this._versusTrophies;
            set => this._versusTrophies = value;
        } // end property VersusTrophies

        #endregion
    } // end class ClanMemberResult
} // end namespace
