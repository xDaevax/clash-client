using System;
using Newtonsoft.Json;

namespace ClashClient.Players {
    /// <summary>
    /// Type that represents basic information about a player.
    /// </summary>
    [Serializable]
    public class PlayerSummary {
        #region --Fields--

        private int _experienceLevel;
        private LeageResult _leage;
        private string _name;
        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializies a new instance of the <see cref="PlayerSummary"/> class.
        /// </summary>
        public PlayerSummary() {
            this._experienceLevel = 0;
            this._leage = new LeageResult();
            this._name = string.Empty;
            this._tag = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the experience level of the player.
        /// </summary>
        [JsonProperty("experienceLevel")]
        public virtual int ExperienceLevel {
            get => this._experienceLevel;
            set => this._experienceLevel = value;
        } // end property ExperienceLevel

        /// <summary>
        /// Gets or sets the <see cref="LeageResult"/> that the player is in.
        /// </summary>
        [JsonProperty("league")]
        public virtual LeageResult Leage {
            get => this._leage;
            set => this._leage = value ?? new LeageResult();
        } // end propety Leage

        /// <summary>
        /// Gets or sets the name of the player
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the tag identifying the player.
        /// </summary>
        [JsonProperty("tag")]
        public virtual string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class PlayerSummary
} // end namespace
