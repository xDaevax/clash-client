using System.Collections.Generic;
using System.Linq;

namespace ClashClient.Net {
    /// <summary>
    /// General response holder for responses from an API.
    /// </summary>
    /// <typeparam name="TResponse">The type of response expected from the API.</typeparam>
    public class ApiResponse<TResponse> {
        #region --Instance Variables--

        private int _httpStatusCode;
        private TResponse _data;
        private List<ApiMessage> _messages;
        private bool _successful;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse() {
            this._httpStatusCode = -1;
            this._data = default(TResponse);
            this._messages = new List<ApiMessage>();
            this._successful = false;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the data returned by the clash of clans API.
        /// </summary>
        public virtual TResponse Data {
            get => this._data;
            set => this._data = value;
        } //  end property Data

        /// <summary>
        /// Gets or sets the HTTP status code returned from the API call.
        /// </summary>
        public virtual int HttpStatusCode {
            get => this._httpStatusCode;
            set => this._httpStatusCode = value;
        } // end property HttpStatusCode

        /// <summary>
        /// Gets or sets a collection of <see cref="ApiMessage"/> instances with details about the API response.
        /// </summary>
        public virtual IEnumerable<ApiMessage> Messages {
            get => this._messages.AsEnumerable();
            set => this._messages = value != null ? value.ToList() : new List<ApiMessage>();
        } // end property Messages

        /// <summary>
        /// Gets or sets a value indicating whether the response came back successfully.
        /// </summary>
        public virtual bool Successful {
            get => this._successful;
            set => this._successful = value;
        } // end property Successful

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
