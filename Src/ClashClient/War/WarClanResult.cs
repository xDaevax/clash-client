using System;
using System.Collections.ObjectModel;
using ClashClient.Clans;
using Newtonsoft.Json;

namespace ClashClient.War {
    /// <summary>
    /// Type that stores war-related information about a clan.
    /// </summary>
    [Serializable]
    public class WarClanResult {
        #region --Fields--

        private int _attackCount;
        private BadgeInfo _badgeUrls;
        private int _clanLevel;
        private double _destructionPercentage;
        private int _experienceEarned;
        private Collection<WarMember> _members;
        private string _name;
        private int _stars;
        private string _tag;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="WarClanResult"/> class.
        /// </summary>
        public WarClanResult() {
            this._attackCount = 0;
            this._badgeUrls = new BadgeInfo();
            this._clanLevel = 0;
            this._destructionPercentage = 0d;
            this._experienceEarned = 0;
            this._members = new Collection<WarMember>();
            this._name = string.Empty;
            this._stars = 0;
            this._tag = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the number of attacks by the clan.
        /// </summary>
        [JsonProperty("attacks")]
        public int AttackCount {
            get => this._attackCount;
            set => this._attackCount = value;
        } // end property AttackCount

        /// <summary>
        /// Gets or sets the <see cref="BadgeInfo"/> instance with badge images for the clan.
        /// </summary>
        [JsonProperty("badgeUrls")]
        public BadgeInfo BadgeUrls {
            get => this._badgeUrls;
            set => this._badgeUrls = value ?? new BadgeInfo();
        } // end property BadgeUrls

        /// <summary>
        /// Gets or sets the level of the clan during the war.
        /// </summary>
        [JsonProperty("clanLevel")]
        public int ClanLevel {
            get => this._clanLevel;
            set => this._clanLevel = value;
        } // end property ClanLevel

        /// <summary>
        /// Gets or sets the destruction percentage inflcited by the clan in the war.
        /// </summary>
        [JsonProperty("destructionPercentage")]
        public double DestructionPercentage {
            get => this._destructionPercentage;
            set => this._destructionPercentage = value;
        } // end property DestructionPercentage

        /// <summary>
        /// Gets or sets the amount of clan experience earned in the war.
        /// </summary>
        [JsonProperty("expEarned")]
        public int ExperienceEarned {
            get => this._experienceEarned;
            set => this._experienceEarned = value;
        } // end property ExperienceEarned

        /// <summary>
        /// Gets or sets the set of <see cref="WarMember"/>s in the war.
        /// </summary>
        [JsonProperty("members")]
        public Collection<WarMember> Members {
            get => this._members;
            set => this._members = value ?? new Collection<WarMember>();
        } // end property Members

        /// <summary>
        /// Gets or sets the name of the clan.
        /// </summary>
        [JsonProperty("name")]
        public string Name {
            get => this._name;
            set => this._name = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Name

        /// <summary>
        /// Gets or sets the number of stars earned by the clan in this war.
        /// </summary>
        [JsonProperty("stars")]
        public int Stars {
            get => this._stars;
            set => this._stars = value;
        } // end property Stars

        /// <summary>
        /// Gets or sets the clan tag.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag {
            get => this._tag;
            set => this._tag = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Tag

        #endregion
    } // end class WarClanResult
} // end namespace
