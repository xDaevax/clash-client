using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashClient.Configuration {
    /// <summary>
    /// Interface that exposes a contract for a type that is capable of reading in configuration data.
    /// </summary>
    public interface IConfigurationProvider {
        #region --Functions--

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>the configuration value associated with the specified key; null otherwise</returns>
        object GetValue(string key);

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/> as a <typeparamref name="TValue"/> instance.
        /// </summary>
        /// <typeparam name="TValue">The type of value being loaded from configuration</typeparam>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <returns>The configuration value associated with the given <paramref name="key"/>; null otherwise</returns>
        TValue GetValue<TValue>(string key);

        /// <summary>
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configurtation.
        /// </summary>
        /// <param name="key">The key of the value being checked.</param>
        /// <returns>true if the key is present in the configuration; false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is empty.</exception>
        bool HasValue(string key);

        /// <summary>
        /// Returns a boolean value indicating whether or not the value was loaded successfully.
        /// </summary>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <param name="value">The value stored in configuration (if loaded)</param>
        /// <returns>true if the value was loaded into the <paramref name="value"/> parameter; false otherwise</returns>
        bool TryGetValue(string key, out object value);

        /// <summary>
        /// Returns a boolean value indicating whether or not the value was loaded successfully.
        /// </summary>
        /// <typeparam name="TValue">The type of value stored in configuration.</typeparam>
        /// <param name="key">The key of the value being retrieved.</param>
        /// <param name="value">The value stored in configuration (if loaded) as a <typeparamref name="TValue"/> instance.</param>
        /// <returns>true if the value was loaded into the <paramref name="value"/> parameter; false otherwise</returns>
        bool TryGetValue<TValue>(string key, out TValue value);

        #endregion
    } // end interface IConfigurationProvider
} // end namespace
