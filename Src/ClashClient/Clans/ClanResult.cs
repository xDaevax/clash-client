using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Clans {
    /// <summary>
    /// Class that represents and individual search result for a clan.
    /// </summary>
    [Serializable]
    public class ClanResult {
        #region --Instance Variables--

        private int _level;
        private ClanLocation _location;
        private string _name;
        private string _tag;
        private int _warWins;

        #endregion

        #region --Constructor--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanResult"/> class.
        /// </summary>
        public ClanResult() {
            this._level = 1;
            this._location = new ClanLocation();
            this._name = string.Empty;
            this._tag = string.Empty;
            this._warWins = 0;
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
        /// Gets or sets the number of war wins the clan has.
        /// </summary>
        [JsonProperty("warWins")]
        public virtual int WarWins {
            get {
                return this._warWins;
            } set {
                this._warWins = value;
            }
        } // end property WarWins

        #endregion
    } // end class ClanResult
} // end namespace
