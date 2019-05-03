using System;
using Newtonsoft.Json;

namespace ClashClient.War {
    /// <summary>
    /// Type that represents an individual war attack.
    /// </summary>
    [Serializable]
    public class WarAttack {
        #region --Fields--

        private string _attackerTag;
        private string _defenderTag;
        private double _destructionPercentage;
        private int _order;
        private int _stars;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="WarAttack"/> class.
        /// </summary>
        public WarAttack() {
            this._attackerTag = string.Empty;
            this._defenderTag = string.Empty;
            this._destructionPercentage = 0d;
            this._order = -1;
            this._stars = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the player tag of the attacker.
        /// </summary>
        [JsonProperty("attackerTag")]
        public string AttackerTag {
            get => this._attackerTag;
            set => this._attackerTag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property AttackerTag

        /// <summary>
        /// Gets or sets the player tag of the defender.
        /// </summary>
        [JsonProperty("defenderTag")]
        public string DefenderTag {
            get => this._defenderTag;
            set => this._defenderTag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property DefenderTag

        /// <summary>
        /// Gets or sets the destruction percentage of the attack.
        /// </summary>
        [JsonProperty("destructionPercentage")]
        public double DestructionPercentage {
            get => this._destructionPercentage;
            set => this._destructionPercentage = value;
        } // end property DestructionPercentage

        /// <summary>
        /// Gets or sets the order that this attack occurred in relative to the war attacks.
        /// </summary>
        [JsonProperty("order")]
        public int Order {
            get => this._order;
            set => this._order = value;
        } // end property Order

        /// <summary>
        /// Gets or sets the number of stars acquired in the attack.
        /// </summary>
        [JsonProperty("stars")]
        public int Stars {
            get => this._stars;
            set => this._stars = value;
        } // end property Stars

        #endregion
    } // end class WarAttack
} // end namespace
