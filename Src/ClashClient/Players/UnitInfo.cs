using System;
using Newtonsoft.Json;

namespace ClashClient.Players {
    /// <summary>
    /// Type that represents unit information for a player (heroes, troops, and spells).
    /// </summary>
    [Serializable]
    public class UnitInfo {
        #region --Fields--

        private int _level;
        private int _maximumLevel;
        private string _name;
        private VillageTarget _village;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitInfo"/> class.
        /// </summary>
        public UnitInfo() {
            this._level = 0;
            this._maximumLevel = 0;
            this._name = string.Empty;
            this._village = VillageTarget.Unknown;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the current troop level.
        /// </summary>
        [JsonProperty("level")]
        public int Level {
            get => this._level;
            set => this._level = value;
        } // end property Level

        /// <summary>
        /// Gets or sets the maximum possible level for this troop.
        /// </summary>
        [JsonProperty("maxLevel")]
        public int MaximumLevel {
            get => this._maximumLevel;
            set => this._maximumLevel = value;
        } // end property MaxLevel

        /// <summary>
        /// Gets or sets the name of the troop.
        /// </summary>
        [JsonProperty("name")]
        public string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the <see cref="VillageTarget"/> to which this unit belongs.
        /// </summary>
        [JsonProperty("village")]
        public VillageTarget Village {
            get => this._village;
            set => this._village = value;
        } // end property Village

        #endregion
    } // end class UnitInfo
} // end namespace
