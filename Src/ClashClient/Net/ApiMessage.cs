using System;
using System.Collections.Generic;
using System.Linq;

namespace ClashClient.Net {
    /// <summary>
    /// Type used to represent a message returned from an API call.
    /// </summary>
    [Serializable]
    public class ApiMessage {
        #region --Fields--

        private List<ApiMessageCategory> _categories;
        private string _text;
        private string _apiStatusCode;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        public ApiMessage() : this(string.Empty) {
        } // end default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text or contents.</param>
        /// <param name="categories">A set of <see cref="ApiMessageCategory"/> instances to apply to the message.</param>
        public ApiMessage(string text, params ApiMessageCategory[] categories) : this(text, string.Empty, categories) {
        } // end overloaded constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text or contents.</param>
        /// <param name="categories">A set of <see cref="ApiMessageCategory"/> instances to apply to the message.</param>
        /// <param name="apiStatusCode">A status code of the message. </param>
        public ApiMessage(string text, string apiStatusCode, params ApiMessageCategory[] categories) {
            this._text = text;
            this._categories = categories?.ToList() ?? new List<ApiMessageCategory>();
            this._apiStatusCode = apiStatusCode;
        } // end overloaded constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the set of <see cref="ApiMessageCategory"/> instances applied to this message.
        /// </summary>
        public virtual IEnumerable<ApiMessageCategory> Categories {
            get => this._categories.AsEnumerable();
            set => this._categories = value != null ? value.ToList() : new List<ApiMessageCategory>();
        } // end property Categories

        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        public virtual string Text {
            get => this._text;
            set => this._text = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Text

        /// <summary>
        /// Gets or sets the status code of the message.
        /// </summary>
        public virtual string StatusCode {
            get => this._apiStatusCode;
            set => this._apiStatusCode = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property StatusCode

        #endregion
    } // end class ApiMessage
} // end namespace
