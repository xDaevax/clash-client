using System;

namespace ClashClient.Net {
    /// <summary>
    /// Type that represents a message returned from the API.
    /// </summary>
    [Serializable]
    public class ApiMessage {
        #region --Fields--

        private ApiMessageCategory _category;
        private string _code;
        private string _text;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        public ApiMessage() : this(string.Empty, string.Empty, ApiMessageCategory.Unspecified) {
        } // end default constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text.</param>
        public ApiMessage(string text) : this(text, string.Empty, ApiMessageCategory.Unspecified) {
        } // end overloaded constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="category">A <see cref="ApiMessageCategory"/> value that categorizes the message.</param>
        public ApiMessage(ApiMessageCategory category) : this(string.Empty, string.Empty, category) {
        } // end overloaded constructor

        /// <summary>
        /// Initialies a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <param name="code">A code identifying the message.</param>
        public ApiMessage(string text, string code) : this(text, code, ApiMessageCategory.Unspecified) {
        } // end overloaded constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <param name="category">A <see cref="ApiMessageCategory"/> value that categorizes the message.</param>
        public ApiMessage(string text, ApiMessageCategory category) : this(text, string.Empty, category) {
        } // end overloaded constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMessage"/> class.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <param name="code">A code identifying the message.</param>
        /// <param name="category">A <see cref="ApiMessageCategory"/> value that categorizes the message.</param>
        public ApiMessage(string text, string code, ApiMessageCategory category) {
            this.Category = category;
            this.Code = code;
            this._text = text;
        } // end overloaded constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets the category of the message.
        /// </summary>
        public ApiMessageCategory Category {
            get => this._category;
            private set => this._category = value;
        } // end property Category

        /// <summary>
        /// Gets or sets the code that identifies the message.
        /// </summary>
        public string Code {
            get => this._code;
            private set => this._code = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Code

        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        public string Text {
            get => this._text;
            set => this._text = string.IsNullOrEmpty(value) ? string.Empty : value;
        } // end property Text

        #endregion
    } // end class ApiMessage
} // end namespace
