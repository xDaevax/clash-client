using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Net {
    /// <summary>
    /// General response holder for responses from an API.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected from the API.</typeparam>
    public class ApiResponse<TResponse> {
        #region --Instance Variables--

        private TResponse _data;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse() {
            this._data = default(TResponse);
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the data returned by the clash of clans API.
        /// </summary>
        public virtual TResponse Data {
            get {
                return this._data;
            } set {
                this._data = value;
            }
        } //  end property Data

        #endregion
    } // end class ApiResponse

    /// <summary>
    /// Non-generic implementation of the ApiResponse type.
    /// General response holder for responses from an API.
    /// </summary>
    public class ApiResponse : ApiResponse<object> {
        #region --Instance Variables--
        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse()
            : base() {
        } // end default constructor

        #endregion
    } // end class ApiResponse
} // end namespace
