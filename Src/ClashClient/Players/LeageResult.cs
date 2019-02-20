using System;
using ClashClient.Clans;
using Newtonsoft.Json;

namespace ClashClient.Players {
    /// <summary>
    /// Type that represents an individual league.
    /// </summary>
    [Serializable]
    public class LeageResult {
        #region --Fields--

        private BadgeInfo _iconUrls;
        private int _id;
        private string _name;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="LeageResult"/> class.
        /// </summary>
        public LeageResult() {
            this._id = -1;
            this._iconUrls = new BadgeInfo();
            this._name = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the unique identifier of the league.
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id {
            get => this._id;
            set => this._id = value;
        } // end property Id

        /// <summary>
        /// Gets or sets the <see cref="BadgeInfo"/> with icon urls for the league.
        /// </summary>
        [JsonProperty("iconUrls")]
        public virtual BadgeInfo IconUrls {
            get => this._iconUrls;
            set => this._iconUrls = value ?? new BadgeInfo();
        } // end property IconUrls

        /// <summary>
        /// Gets or sets the name of the league.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        #endregion
    } // end class LeagueResult
} // end namespace
