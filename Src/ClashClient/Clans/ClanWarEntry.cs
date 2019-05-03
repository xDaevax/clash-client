using System;
using ClashClient.War;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents an entry in a clan's war log.
    /// </summary>
    [Serializable]
    public class ClanWarEntry {
        #region --Fields--

        private WarClanResult _clan;
        private DateTimeOffset _endTime;
        private WarClanResult _opponent;
        private WarOutcome _result;
        private int _teamSize;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanWarEntry"/> class.
        /// </summary>
        public ClanWarEntry() {
            this._clan = new WarClanResult();
            this._endTime = DateTimeOffset.MinValue;
            this._opponent = new WarClanResult();
            this._result = WarOutcome.Tie;
            this._teamSize = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the <see cref="WarClanResult"/> info from the current clan's perspective
        /// </summary>
        [JsonProperty("clan")]
        public WarClanResult Clan {
            get => this._clan;
            set => this._clan = value ?? new WarClanResult();
        } // end property Clan

        /// <summary>
        /// Gets or sets the date / time (with offset) that the war ended.
        /// </summary>
        [JsonProperty("endTime")]
        public DateTimeOffset EndTime {
            get => this._endTime;
            set => this._endTime = value;
        } // end property EndTime

        /// <summary>
        /// Gets or sets the <see cref="WarClanResult"/> of the opposing clan from the current clan's perspective.
        /// </summary>
        [JsonProperty("opponent")]
        public WarClanResult Opponent {
            get => this._opponent;
            set => this._opponent = value ?? new WarClanResult();
        } // end property Opponent

        /// <summary>
        /// Gets or sets the <see cref="WarOutcome"/> of the war.
        /// </summary>
        [JsonProperty("result")]
        public WarOutcome Result {
            get => this._result;
            set => this._result = value;
        } // end property Result

        /// <summary>
        /// Gets or sets the size of the teams in the war.
        /// </summary>
        [JsonProperty("teamSize")]
        public int TeamSize {
            get => this._teamSize;
            set => this._teamSize = value;
        } // end property TeamSize

        #endregion
    } // end class ClanWarEntry
} // end namespace
