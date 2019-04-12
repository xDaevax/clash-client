using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClashClient.Common.Configuration;

namespace ClashClient.Configuration {
    /// <summary>
    /// Configuration Provider type that has no external dependencies and stores configuration data in memory.
    /// This class is intended 
    /// </summary>
    public class InMemoryConfigurationProvider : IConfigurationProvider {
        #region --Instance Variables--

        private readonly StringComparer _comparer;
        private readonly Dictionary<string, object> _configuration;

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
        /// <exception cref="ApplicationException">Thrown if the configuration cannot be written to.</exception>
        public virtual void AddValue(string name, object value) {
            if (this.CanWrite()) {
                this._configuration.Add(name, value);
            } else {
                throw new ApplicationException("The configuration cannot be modified.");
            }
        } // end method AddValue

        #endregion

        #region --Functions--

        /// <summary>
        /// Gets a value indicating whether or not this provider is capable of writing to configuration data.
        /// </summary>
        /// <returns>true</returns>
        public virtual bool CanWrite() {
            return true;
        } // end function CanWrite

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>the configuration value associated with the specified key; null otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is null or empty</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the given <paramref name="key"/> is not found</exception>
        public virtual object GetValue(string key) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new ArgumentNullException(nameof(key), "No setting key provided to look-up.");
            }

            if (!this.HasKey(key)) {
                throw new KeyNotFoundException("The specified key could not be found: " + key);
            }

            object returnValue = null;

            returnValue = this._configuration[key];

            return returnValue;
        } // end function GetValue

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/> as a <typeparamref name="TValue"/> instance.
        /// </summary>
        /// <typeparam name="TValue">The type of value being loaded from configuration</typeparam>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>The configuration value associated with the given <paramref name="key"/>; null otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is null or empty</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the given <paramref name="key"/> is not found</exception>
        /// <exception cref="InvalidCastException">Thrown if the value cannot be unboxed to the given <typeparamref name="TValue"/> type.</exception>
        public virtual TValue GetValue<TValue>(string key) {
            object value = this.GetValue(key);
            var returnValue = default(TValue);
            if (value != null) {
                returnValue = (TValue)Convert.ChangeType(value, typeof(TValue));
            }

            return returnValue;
        } // end function GetValue

        /// <summary>
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configurtation.
        /// </summary>
        /// <param name="key">The key of the value being checked.</param>
        /// <returns>true if the key is present in the configuration; false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is empty.</exception>
        public virtual bool HasKey(string key) {
            if (string.IsNullOrWhiteSpace(key)) {
                throw new ArgumentNullException("key", "No key provided.");
            }

            return this._configuration.Any(x => this._comparer.Equals(x.Key, key));
        } // end function HasKey

        /// <summary>
        /// Returns a boolean value indicating whether or not the value was loaded successfully.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <param name="value">The value stored in configuration (if loaded)</param>
        /// <returns>true if the value was loaded into the <paramref name="value"/> parameter; false otherwise</returns>
        public virtual bool TryGetValue(string key, out object value) {
            bool returnValue = false;
            if (!string.IsNullOrWhiteSpace(key) && this.HasKey(key)) {
                value = this._configuration[key];
                returnValue = true;
            } else {
                value = null;
                returnValue = false;
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
            if (this.TryGetValue(key, out var boxedValue)) {
                var genericType = typeof(TValue);
                if (genericType.IsValueType || genericType.IsPrimitive || genericType == typeof(string)) {
                    value = (TValue)Convert.ChangeType(boxedValue, typeof(TValue));
                    returnValue = true;
                } else if (boxedValue != null && boxedValue.GetType().IsAssignableFrom(typeof(TValue))) {
                    value = (TValue)boxedValue;
                    returnValue = true;
                } else {
                    value = default(TValue);
                    returnValue = false;
                }
            } else {
                returnValue = false;
                value = default(TValue);
            }

            return returnValue;
        } // end function TryGetValue

        #endregion
    } // end class InMemoryConfigurationProvider
} // end namespace
