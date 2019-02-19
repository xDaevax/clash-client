using System;
using System.Collections.Generic;
using System.Web;

namespace ClashClient.Net {
    /// <summary>
    /// Class used to format name value pairs as a query-string.
    /// </summary>
    public class QueryStringFormatter {
        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryStringFormatter"/> class.
        /// </summary>
        public QueryStringFormatter() {
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Formats the given set of <paramref name="name"/> and <paramref name="value"/> pairs for use in a query-string.
        /// </summary>
        /// <param name="name">The portion of the query-string that will be the name of the pair.</param>
        /// <param name="value">The value to be formetted.</param>
        /// <returns>A name / value pair formatted for a query-string</returns>
        public virtual KeyValuePair<string, string> Format(string name, object value) {
            return this.Format(name, value, false);
        } // end function Format

        /// <summary>
        /// Formats the given set of <paramref name="name"/> and <paramref name="value"/> pairs for use in a query-string.
        /// </summary>
        /// <param name="name">The portion of the query-string that will be the name of the pair.</param>
        /// <param name="value">The value to be formetted.</param>
        /// <param name="allowEmptyValue">true to allow a null value; false to throw an exception if the value is null.</param>
        /// <returns>A name / value pair formatted for a query-string</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="name"/> is null or if the <paramref name="allowEmptyValue"/> is true and the <paramref name="value"/> is null</exception>
        public virtual KeyValuePair<string, string> Format(string name, object value, bool allowEmptyValue) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException(nameof(name), "No name provided");
            }

            if (!allowEmptyValue && value == null) {
                throw new ArgumentNullException(nameof(value), "No value provided.");
            }

            KeyValuePair<string, string> formattedValue;

            string processedValue = value.ToString();
            processedValue = HttpUtility.UrlEncode(processedValue);

            formattedValue = new KeyValuePair<string, string>(name, processedValue);

            return formattedValue;
        } // end function Format

        #endregion
    } // end class QueryStringFormatter
} // end namespace
