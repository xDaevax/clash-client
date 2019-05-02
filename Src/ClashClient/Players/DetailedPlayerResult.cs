using System;
using ClashClient.Clans;
using Newtonsoft.Json;

namespace ClashClient.Players {
    /// <summary>
    /// Type that represents the detailed information available about a player.
    /// </summary>
    [Serializable]
    public class DetailedPlayerResult : PlayerSummary {
        #region --Fields--

        private int _attackWins;
        private int _bestTrophies;
        private int _bestVersusTrophies;
        private int _builderHallLevel;
        private ClanSummary _clan;
        private int _defenseWins;
        private int _donations;
        private int _donationsReceived;
        private string _role;
        private int _townhallLevel;
        private int _trophies;
        private int _versusBattleWinCount;
        private int _versusBattleWins;
        private int _versusTrophies;
        private int _warStars;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedPlayerResult"/> class.
        /// </summary>
        public DetailedPlayerResult() : base() {
            this._attackWins = 0;
            this._bestTrophies = 0;
            this._bestVersusTrophies = 0;
            this._builderHallLevel = 0;
            this._clan = new ClanSummary();
            this._defenseWins = 0;
            this._donations = 0;
            this._donationsReceived = 0;
            this._role = string.Empty;
            this._townhallLevel = 0;
            this._trophies = 0;
            this._versusBattleWinCount = 0;
            this._versusBattleWins = 0;
            this._versusTrophies = 0;
            this._warStars = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the number of attacks win this player has this season.
        /// </summary>
        [JsonProperty("attackWins")]
        public int AttackWins {
            get => this._attackWins;
            set => this._attackWins = value;
        } // end property AttackWins

        /// <summary>
        /// Gets or sets the highest trophy count this player has reached.
        /// </summary>
        [JsonProperty("bestTrophies")]
        public int BestTrophies {
            get => this._bestTrophies;
            set => this._bestTrophies = value;
        } // end property BestTrophies

        /// <summary>
        /// Gets or sets the highest builder base trophy count this player has reached.
        /// </summary>
        [JsonProperty("bestVersusTrophies")]
        public int BestVersusTrophies {
            get => this._bestVersusTrophies;
            set => this._bestVersusTrophies = value;
        } // end property BestVersusTrophies

        /// <summary>
        /// Gets or sets this players current builder hall level.
        /// </summary>
        [JsonProperty("builderHallLevel")]
        public int BuilderHallLevel {
            get => this._builderHallLevel;
            set => this._builderHallLevel = value;
        } // end property BuilderHallLevel

        /// <summary>
        /// Gets or sets the <see cref="ClanSummary"/> instance with information about which clan this player is currently a member of.
        /// </summary>
        [JsonProperty("clan")]
        public ClanSummary Clan {
            get => this._clan;
            set => this._clan = value ?? new ClanSummary();
        } // end property Clan

        /// <summary>
        /// Gets or sets the number of defensive wins this player has this season.
        /// </summary>
        [JsonProperty("defenseWins")]
        public int DefenseWins {
            get => this._defenseWins;
            set => this._defenseWins = value;
        } // end property DefenseWins

        /// <summary>
        /// Gets or sets the number of donations this player has this season.
        /// </summary>
        [JsonProperty("donations")]
        public int Donations {
            get => this._donations;
            set => this._donations = value;
        } // end property Donations

        /// <summary>
        /// Gets or sets the number of donations this player has received this season.
        /// </summary>
        [JsonProperty("donationsReceived")]
        public int DonationsReceived {
            get => this._donationsReceived;
            set => this._donationsReceived = value;
        } // end property DonationsReceived

        /// <summary>
        /// Gets or sets the role of this player in their current clan (if any).
        /// </summary>
        [JsonProperty("role")]
        public string Role {
            get => this._role;
            set => this._role = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Role

        /// <summary>
        /// Gets or sets the current town hall level for this player.
        /// </summary>
        [JsonProperty("townhallLevel")]
        public int TownhallLevel {
            get => this._townhallLevel;
            set => this._townhallLevel = value;
        } // end property TownhallLevel

        /// <summary>
        /// Gets or sets the number of trophies this player has.
        /// </summary>
        [JsonProperty("trophies")]
        public int Trophies {
            get => this._trophies;
            set => this._trophies = value;
        } // end property Trophies

        /// <summary>
        /// Gets or sets the total number of versus battle wins this player has.
        /// </summary>
        [JsonProperty("versusBattleWinCount")]
        public int VersusBattleWinCount {
            get => this._versusBattleWinCount;
            set => this._versusBattleWinCount = value;
        } // end property VersusBattleWinCount

        /// <summary>
        /// Gets or sets the number of versus battles this player has won this season.
        /// </summary>
        [JsonProperty("versusBattleWins")]
        public int VersusBattleWins {
            get => this._versusBattleWins;
            set => this._versusBattleWins = value;
        } // end property VersusBattleWins

        /// <summary>
        /// Gets or sets the number of versus trophies this player has.
        /// </summary>
        [JsonProperty("versusTrophies")]
        public int VersusTrophies {
            get => this._versusTrophies;
            set => this._versusTrophies = value;
        } // end property VersusTrophies

        /// <summary>
        /// Gets or sets the number of war stars this player has.
        /// </summary>
        [JsonProperty("warStars")]
        public int WarStars {
            get => this._warStars;
            set => this._warStars = value;
        } // end property WarStars

        #endregion
    } // end class DetailedPlayerResult
} // end namespace
