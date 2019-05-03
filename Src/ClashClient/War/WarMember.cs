using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ClashClient.War {
    /// <summary>
    /// Type that represents the data associated with a clan member in a war.
    /// </summary>
    [Serializable]
    public class WarMember {
        #region --Fields--

        private Collection<WarAttack> _attacks;
        private WarAttack _bestOpponentAttack;
        private int _mapPosition;
        private string _name;
        private int _opponentAttackCount;
        private string _tag;
        private int _townhallLevel;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="WarMember"/> class.
        /// </summary>
        public WarMember() {
            this._attacks = new Collection<WarAttack>();
            this._bestOpponentAttack = new WarAttack();
            this._mapPosition = -1;
            this._name = string.Empty;
            this._opponentAttackCount = 0;
            this._tag = string.Empty;
            this._townhallLevel = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the set of <see cref="WarAttack"/> instances made by this member.
        /// </summary>
        [JsonProperty("attacks")]
        public Collection<WarAttack> Attacks {
            get => this._attacks;
            set => this._attacks = value ?? new Collection<WarAttack>();
        } // end property Attacks

        /// <summary>
        /// Gets or sets the best <see cref="WarAttack"/> made by the opponent (if any).
        /// </summary>
        [JsonProperty("bestOpponentAttack")]
        public WarAttack BestOpponentAttack {
            get => this._bestOpponentAttack;
            set => this._bestOpponentAttack = value ?? new WarAttack();
        } // end property BestOpponentAttack

        /// <summary>
        /// Gets or sets the position of this member on the war map.
        /// </summary>
        [JsonProperty("mapPosition")]
        public int MapPosition {
            get => this._mapPosition;
            set => this._mapPosition = value;
        } // end property MapPosition

        /// <summary>
        /// Gets or sets the name of this member.
        /// </summary>
        [JsonProperty("name")]
        public string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the number of attacks made on this member by war opponents.
        /// </summary>
        [JsonProperty("opponentAttacks")]
        public int OpponentAttackCount {
            get => this._opponentAttackCount;
            set => this._opponentAttackCount = value;
        } // end property OpponentAttackCount

        /// <summary>
        /// Gets or sets the player tag of this member.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        /// <summary>
        /// Gets or sets the townhall level of this member during the war.
        /// </summary>
        [JsonProperty("townhallLevel")]
        public int TownhallLevel {
            get => this._townhallLevel;
            set => this._townhallLevel = value;
        } // end property TownhallLevel

        #endregion
    } // end class WarMember
} // end namespace
