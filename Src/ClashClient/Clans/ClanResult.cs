using System;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Class that represents and individual search result for a clan.
    /// </summary>
    [Serializable]
    public class ClanResult : ClanSummary {
        #region --Instance Variables--

        private bool _isWarLogPublic;
        private ClanLocation _location;
        private int _members;
        private MembershipType _membershipType;
        private int _points;
        private int _requiredTrophies;
        private int _versusPoints;
        private WarFrequency _warFrequency;
        private int _warLosses;
        private int _warTies;
        private int _warWins;
        private int _warWinStreak;

        #endregion

        #region --Constructor--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanResult"/> class.
        /// </summary>
        public ClanResult() : base() {
            this._isWarLogPublic = false;
            this._location = new ClanLocation();
            this._members = -1;
            this._membershipType = MembershipType.Unknown;
            this._points = -1;
            this._requiredTrophies = 0;
            this._versusPoints = 0;
            this._warFrequency = WarFrequency.Unknown;
            this._warLosses = 0;
            this._warTies = 0;
            this._warWins = 0;
            this._warWinStreak = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets a value indicating whether the clan's war log has been made public.
        /// </summary>
        [JsonProperty("isWarLogPublic")]
        public virtual bool IsWarLogPublic {
            get => this._isWarLogPublic;
            set => this._isWarLogPublic = value;
        } // end property IsWarLogPublic

        /// <summary>
        /// Gets or sets the location for the clan.
        /// </summary>
        [JsonProperty("location")]
        public virtual ClanLocation Location {
            get {
                return this._location;
            } set {
                if (value != null) {
                    this._location = value;
                }
            }
        } // end property Location

        /// <summary>
        /// Gets or sets the number of members in the clan.
        /// </summary>
        [JsonProperty("members")]
        public virtual int Members {
            get => this._members;
            set => this._members = value;
        } // end property Members

        /// <summary>
        /// Gets or sets the <see cref="Clans.MembershipType"/> of the clan.
        /// </summary>
        [JsonProperty("type")]
        public virtual MembershipType MembershipType {
            get => this._membershipType;
            set => this._membershipType = value;
        } // end property MembershipType

        /// <summary>
        /// Gets or sets the number of points the clan has.
        /// </summary>
        [JsonProperty("clanPoints")]
        public virtual int Points {
            get => this._points;
            set => this._points = value;
        } // end property Points

        /// <summary>
        /// Gets or sets the number of trophies required to join the clan.
        /// </summary>
        [JsonProperty("requiredTrophies")]
        public virtual int RequiredTrophies {
            get => this._requiredTrophies;
            set => this._requiredTrophies = value;
        } // end property RequiredTrophies

        /// <summary>
        /// Gets or sets the number of versus points the clan has.
        /// </summary>
        [JsonProperty("clanVersusPoints")]
        public virtual int VersusPoints {
            get {
                return this._versusPoints;
            } set {
                this._versusPoints = value;
            }
        } // end property VersusPoints

        /// <summary>
        /// Gets or sets the clans <see cref="Clans.WarFrequency"/>.
        /// </summary>
        [JsonProperty("warFrequency")]
        public virtual WarFrequency WarFrequency {
            get => this._warFrequency;
            set => this._warFrequency = value;
        } // end property WarFrequency

        /// <summary>
        /// Gets or sets the number of war losses the clan has.
        /// </summary>
        [JsonProperty("warLosses")]
        public virtual int WarLosses {
            get => this._warLosses;
            set => this._warLosses = value;
        } // end property WarLosses

        /// <summary>
        /// Gets or sets the number of war ties the clan has.
        /// </summary>
        [JsonProperty("warTies")]
        public virtual int WarTies {
            get => this._warTies;
            set => this._warTies = value;
        } // end property WarTies

        /// <summary>
        /// Gets or sets the number of war wins the clan has.
        /// </summary>
        [JsonProperty("warWins")]
        public virtual int WarWins {
            get => this._warWins;
            set => this._warWins = value;
        } // end property WarWins

        /// <summary>
        /// Gets or sets the war win streak for the clan.
        /// </summary>
        [JsonProperty("warWinStreak")]
        public virtual int WarWinStreak {
            get => this._warWinStreak;
            set => this._warWinStreak = value;
        } // end property WarWinStreak

        #endregion
    } // end class ClanResult
} // end namespace
