using System;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Class that represents and individual search result for a clan.
    /// </summary>
    [Serializable]
    public class ClanResult {
        #region --Instance Variables--

        private int _level;
        private ClanLocation _location;
        private int _members;
        private string _name;
        private int _points;
        private string _tag;
        private int _versusPoints;

        #endregion

        #region --Constructor--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanResult"/> class.
        /// </summary>
        public ClanResult() {
            this._level = 1;
            this._location = new ClanLocation();
            this._members = -1;
            this._name = string.Empty;
            this._points = -1;
            this._tag = string.Empty;
            this._versusPoints = 0;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the level of the clan.
        /// </summary>
        [JsonProperty("clanLevel")]
        public virtual int Level {
            get {
                return this._level;
            } set {
                this._level = value;
            }
        } // end property Level

        /// <summary>
        /// Gets or sets the location for the clan.
        /// </summary>
        [JsonProperty("location")]
        public virtual ClanLocation Location {
            get {
                return this._location;
            } set {
                if (value != null) {
                    this._location = value;
                }
            }
        } // end property Location

        /// <summary>
        /// Gets or sets the number of members in the clan.
        /// </summary>
        [JsonProperty("members")]
        public virtual int Members {
            get => this._members;
            set => this._members = value;
        } // end property Members

        /// <summary>
        /// Gets or sets the name of the clan.  This is the name the leader assigned when creating the clan.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name {
            get {
                return this._name;
            } set {
                if (value != null) {
                    this._name = value;
                }
            }
        } // end property Name

        /// <summary>
        /// Gets or sets the number of points the clan has.
        /// </summary>
        [JsonProperty("clanPoints")]
        public virtual int Points {
            get => this._points;
            set => this._points = value;
        } // end property Points

        /// <summary>
        /// Gets or sets the automatically game-assigned identifier or clan-tag for the clan.
        /// </summary>
        [JsonProperty("tag")]
        public virtual string Tag {
            get {
                return this._tag;
            } set {
                if (value != null) {
                    this._tag = value;
                }
            }
        } // end property Tag

        /// <summary>
        /// Gets or sets the number of versus points the clan has.
        /// </summary>
        [JsonProperty("clanVersusPoints")]
        public virtual int VersusPoints {
            get {
                return this._versusPoints;
            } set {
                this._versusPoints = value;
            }
        } // end property VersusPoints

        #endregion
    } // end class ClanResult
} // end namespace
