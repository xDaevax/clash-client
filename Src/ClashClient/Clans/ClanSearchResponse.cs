using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Clans {
    /// <summary>
    /// Type used to store results of a set of clans found to match a clan search request.
    /// </summary>
    [Serializable]
    public class ClanSearchResponse : SearchResponse {
        #region --Instance Variables--

        private Collection<ClanResult> _items;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ClanSearchResponse"/> class.
        /// </summary>
        public ClanSearchResponse()
            : base() {
                this._items = new Collection<ClanResult>();
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the collection of <see cref="ClanResult"/> that match the query.
        /// </summary>
        [JsonProperty("items")]
        public virtual Collection<ClanResult> Items {
            get {
                return this._items;
            } set {
                if(value != null) {
                    this._items = value;
                }
            }
        } // end property Items

        #endregion
    } // end class ClanSearchResponse
} // end namespace
