using System;
using Newtonsoft.Json;

namespace ClashClient.Players {
    /// <summary>
    /// Type that represents an individual achievement / status for a player.
    /// </summary>
    [Serializable]
    public class Achievement {
        #region --Fields--

        private string _info;
        private string _name;
        private int _stars;
        private int _target;
        private int _value;
        private VillageTarget _village;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="Achievement"/> class.
        /// </summary>
        public Achievement() {
            this._info = string.Empty;
            this._name = string.Empty;
            this._stars = 0;
            this._target = 0;
            this._value = 0;
            this._village = VillageTarget.Unknown;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the info or descriptive text of the achievement.
        /// </summary>
        [JsonProperty("info")]
        public string Info {
            get => this._info;
            set => this._info = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Info

        /// <summary>
        /// Gets or sets the name of the achievement.
        /// </summary>
        [JsonProperty("name")]
        public string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the star level reached for this achievement.
        /// </summary>
        [JsonProperty("stars")]
        public int Stars {
            get => this._stars;
            set => this._stars = value;
        } // end property Stars

        /// <summary>
        /// Gets or sets the target value to achieve the next star tier (or the maximum value for the last star tier).
        /// </summary>
        [JsonProperty("target")]
        public int Target {
            get => this._target;
            set => this._target = value;
        } // end property Target

        /// <summary>
        /// Gets or sets the current value of the achievement.
        /// </summary>
        [JsonProperty("value")]
        public int Value {
            get => this._value;
            set => this._value = value;
        } // end property Value

        /// <summary>
        /// Gets or sets the <see cref="VillageTarget"/> that indicates which base / village this achievement is relevant for.
        /// </summary>
        [JsonProperty("village")]
        public VillageTarget Village {
            get => this._village;
            set => this._village = value;
        } // end property Village

        #endregion
    } // end class Achievement
} // end namespace
