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
        private Dictionary<string, object> _configuration;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryConfigurationProvider"/> class.
        /// </summary>
        public InMemoryConfigurationProvider() {
            this._comparer = StringComparer.Create(CultureInfo.CurrentCulture, true);
            this._configuration = new Dictionary<string, object>();
        } // end default constructor

        #endregion

        #region --Methods--

        /// <summary>
        /// Adds a value to the configuration.
        /// </summary>
        /// <param name="name">The name of the config key</param>
        /// <param name="value">The value to store</param>
        protected virtual void AddValue(string name, object value) {
            this._configuration.Add(name, value);
        } // end method AddValue

        #endregion

        #region --Functions--

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>the configuration value associated with the specified key; null otherwise</returns>
        public virtual object GetValue(string key) {
            object returnValue = null;

            if (!string.IsNullOrWhiteSpace(key)) {
                returnValue = this._configuration[key];
            }

            return returnValue;
        } // end function GetValue

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/> as a <typeparamref name="TValue"/> instance.
        /// </summary>
        /// <typeparam name="TValue">The type of value being loaded from configuration</typeparam>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>The configuration value associated with the given <paramref name="key"/>; null otherwise</returns>
        public virtual TValue GetValue<TValue>(string key) {
            TValue returnValue = default(TValue);

            if (!string.IsNullOrWhiteSpace(key)) {
                returnValue = (TValue)this._configuration[key];
            }

            return returnValue;
        } // end function GetValue

        /// <summary>
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configurtation.
        /// </summary>
        /// <param name="key">The key of the value being checked.</param>
        /// <returns>true if the key is present in the configuration; false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is empty.</exception>
        public virtual bool HasValue(string key) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new ArgumentNullException("key", "No key provided.");
            }

            return this._configuration.Any(x => this._comparer.Equals(x.Key, key));
        } // end function HasValue

        /// <summary>
        /// Returns a boolean value indicating whether or not the value was loaded successfully.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <param name="value">The value stored in configuration (if loaded)</param>
        /// <returns>true if the value was loaded into the <paramref name="value"/> parameter; false otherwise</returns>
        public virtual bool TryGetValue(string key, out object value) {
            bool returnValue = false;

            if (this.HasValue(key)) {
                value = this._configuration[key];
            } else {
                value = null;
            }

            return returnValue;
        } // end function TryGetValue

        /// <summary>
        /// Returns a boolean value indicating whether or not the value was loaded successfully.
        /// </summary>
        /// <typeparam name="TValue">The type of value stored in configuration.</typeparam>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <param name="value">The value stored in configuration (if loaded) as a <typeparamref name="TValue"/> instance.</param>
        /// <returns>true if the value was loaded into the <paramref name="value"/> parameter; false otherwise</returns>
        public virtual bool TryGetValue<TValue>(string key, out TValue value) {
            bool returnValue = false;

            if (this.HasValue(key)) {
                object val = this._configuration[key];

                if (val != null) {
                    if(val.GetType().IsAssignableFrom(typeof(TValue))) {
                        value = (TValue)val;
                        returnValue = true;
                    } else {
                        value = default(TValue);
                    }
                } else {
                    value = default(TValue);
                }
            } else {
                value = default(TValue);
            }

            return returnValue;
        } // end function TryGetValue

        #endregion
    } // end class InMemoryConfigurationProvider
} // end namespace
