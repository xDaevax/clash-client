using System;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Type that represents a set of badges for a clan.
    /// </summary>
    [Serializable]
    public class BadgeInfo {
        #region --Fields--

        private string _large;
        private string _medium;
        private string _small;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeInfo"/> class.
        /// </summary>
        public BadgeInfo() {
            this._large = string.Empty;
            this._medium = string.Empty;
            this._small = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the large-size badge url.
        /// </summary>
        [JsonProperty("large")]
        public virtual string Large {
            get => this._large;
            set => this._large = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Large

        /// <summary>
        /// Gets or sets the medium-size badge url.
        /// </summary>
        [JsonProperty("medium")]
        public virtual string Medium {
            get => this._medium;
            set => this._medium = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Medium

        /// <summary>
        /// Gets or sets the small-size badge url.
        /// </summary>
        [JsonProperty("small")]
        public virtual string Small {
            get => this._small;
            set => this._small = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Small

        #endregion
    } // end class BadgeInfo
} // end namespace
