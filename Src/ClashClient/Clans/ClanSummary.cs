using System;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents summary information about a clan.
    /// </summary>
    [Serializable]
    public class ClanSummary {
        #region --Fields--

        private BadgeInfo _badgeUrls;
        private int _clanLevel;
        private string _name;
        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSummary"/> class.
        /// </summary>
        public ClanSummary() {
            this._badgeUrls = new BadgeInfo();
            this._clanLevel = 0;
            this._name = string.Empty;
            this._tag = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the <see cref="BadgeInfo"/> instance with links to the badges for the clan.
        /// </summary>
        [JsonProperty("badgeUrls")]
        public BadgeInfo BadgeUrls {
            get => this._badgeUrls;
            set => this._badgeUrls = value ?? new BadgeInfo();
        } // end property BageUrls

        /// <summary>
        /// Gets or sets the level of the clan.
        /// </summary>
        [JsonProperty("clanLevel")]
        public int ClanLevel {
            get => this._clanLevel;
            set => this._clanLevel = value;
        } // end property ClanLevel

        /// <summary>
        /// Gets or sets the name of the clan.
        /// </summary>
        [JsonProperty("name")]
        public string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the clan tag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class ClanSummary
} // end namespace
