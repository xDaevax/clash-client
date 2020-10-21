using System;
using Newtonsoft.Json;

namespace ClashClient.Clans {
    /// <summary>
    /// Class that represents the location of a clan.
    /// </summary>
    [Serializable]
    public class ClanLocation {
        #region --Instance Variables--

        private string _countryCode;
        private int _id;
        private bool _isCountry;
        private string _name;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanLocation"/> class.
        /// </summary>
        public ClanLocation() {
            this._countryCode = string.Empty;
            this._id = 0;
            this._isCountry = false;
            this._name = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the code shorthand that represents the country.
        /// </summary>
        [JsonProperty("countryCode")]
        public virtual string CountryCode {
            get => this._countryCode; set => this._countryCode = value;
        } // end property CountryCode

        /// <summary>
        /// Gets or sets the unique identifier of the location.
        /// </summary>
        [JsonProperty("id")]
        public virtual int Id {
            get => this._id; set => this._id = value;
        } // end property Id

        /// <summary>
        /// Gets or sets a value indicating whether or not the clan's location specifies a country.
        /// </summary>
        [JsonProperty("isCountry")]
        public virtual bool IsCountry {
            get => this._isCountry; set => this._isCountry = value;
        } // end property IsCountry

        /// <summary>
        /// Gets or sets the name of the location of the clan.  Usually a country.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name {
            get => this._name; set {
                if (value != null) {
                    this._name = value;
                }
            }
        } // end property Name

        #endregion
    } // end class ClanLocation
} // end namespace