using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient {
    /// <summary>
    /// Type that represents an error returned by the API.
    /// </summary>
    [Serializable]
    public class ErrorResponse {
        #region --Instance Variables--

        private string _message;
        private string _reason;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResponse"/> class.
        /// </summary>
        public ErrorResponse() {
            this._message = string.Empty;
            this._reason = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the error message describing the problem.
        /// </summary>
        [JsonProperty("message")]
        public virtual string Message {
            get {
                return this._message;
            } set {
                this._message = value;
            }
        } // end property Message

        /// <summary>
        /// Gets or sets the summary reason for the failure.
        /// </summary>
        [JsonProperty("reason")]
        public virtual string Reason {
            get {
                return this._reason;
            } set {
                this._reason = value;
            }
        } // end property Reason

        #endregion
    } // end class ErrorResponse
} // end namepsace
