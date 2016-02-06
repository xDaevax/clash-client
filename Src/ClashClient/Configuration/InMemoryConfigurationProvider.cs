using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Configuration {
    /// <summary>
    /// Configuration Provider type that has no external dependencies and stores configuration data in memory.
    /// This class is intended 
    /// </summary>
    public class InMemoryConfigurationProvider : IConfigurationProvider {
        #region --Instance Variables--

        private StringComparer _comparer;
        private object _configLock;
        private Dictionary<string, object> _configuration;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryConfigurationProvider"/> class.
        /// </summary>
        public InMemoryConfigurationProvider() {
            this._comparer = StringComparer.Create(CultureInfo.CurrentCulture, true);
            this._configLock = new object();
            this._configuration = new Dictionary<string, object>();
        } // end default constructor

        #endregion

        #region --Functions--

        public object GetValue(string key) {
            throw new NotImplementedException();
        } // end function GetValue

        public TValue GetValue<TValue>(string key) {
            throw new NotImplementedException();
        } // end function GetValue

        /// <summary>
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configurtation.
        /// </summary>
        /// <param name="key">The key of the value being checked.</param>
        /// <returns>true if the key is present in the configuration; false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is empty.</exception>
        public bool HasValue(string key) {
            return this._configuration.Any(x => this._comparer.Equals(x.Key, key));
        } // end function HasValue

        public bool TryGetValue(string key, out object value) {
            throw new NotImplementedException();
        } // end function TryGetValue

        public bool TryGetValue<TValue>(string key, out TValue value) {
            throw new NotImplementedException();
        } // end function TryGetValue

        #endregion
    } // end class InMemoryConfigurationProvider
} // end namespace
