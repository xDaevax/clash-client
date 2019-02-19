using System;
using System.Collections.Generic;

namespace ClashClient.Common.Configuration {
    /// <summary>
    /// Type that exposes functionality for types that allow manipulation of configuration values.
    /// </summary>
    public interface IConfigurationProvider {
        #region --Functions--

        /// <summary>
        /// Returns a value indicating whether or not the provider allows writing to config.
        /// </summary>
        /// <returns>true if the provider can write config values; false otherwise</returns>
        bool CanWrite();

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the value to load from configuration</param>
        /// <returns>A configuration value</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is null or empty</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the given <paramref name="key"/> is not found</exception>
        object GetValue(string key);

        /// <summary>
        /// Returns the configuration value associated with the given <paramref name="key"/> and attempts to unbox it to the given <typeparamref name="TValue"/> type.
        /// </summary>
        /// <typeparam name="TValue">The type to unbox the configuration value to</typeparam>
        /// <param name="key">The key of the value to load from configuration</param>
        /// <returns>A configuration value of the given <typeparamref name="TValue"/> type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is null or empty</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the given <paramref name="key"/> is not found</exception>
        /// <exception cref="InvalidCastException">Thrown if the value cannot be unboxed to the given <typeparamref name="TValue"/> type.</exception>
        TValue GetValue<TValue>(string key);

        /// <summary>
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configuration.
        /// </summary>
        /// <param name="key">The key to look up</param>
        /// <returns>true if a configuration value has been defined with the given <paramref name="key"/>; false otherwise</returns>
        bool HasKey(string key);

        /// <summary>
        /// Returns a value indicating whether or not the configuration value stored with the <paramref name="key"/> was able to be loaded into the <paramref name="value"/> parameter.
        /// This follows the "TrySomething" pattern where exceptions will not be thrown.  This is considered the "safe" method
        /// for loading values from config when exceptions should not be thrown.
        /// </summary>
        /// <param name="key">The key of the value to load from configuration</param>
        /// <param name="value">The variable where the configuration value will be stored (if found).</param>
        /// <returns>true if the value for <paramref name="key"/> was found; false otherwise</returns>
        bool TryGetValue(string key, out object value);

        /// <summary>
        /// Returns a value indicating whether or not the configuration value stored with the <paramref name="key"/> was able to be loaded into the <paramref name="value"/> parameter and unboxed to the given <typeparamref name="TValue"/> type.
        /// This follows the "TrySomething" pattern where exceptions will not be thrown.  This is considered the "safe" method
        /// for loading values from config when exceptions should not be thrown.
        /// </summary>
        /// <typeparam name="TValue">The type to unbox the configuration value to</typeparam>
        /// <param name="key">The key of the value to load from configuration</param>
        /// <param name="value">The variable where the configuration value will be stored (if found).</param>
        /// <returns>true if the value for <paramref name="key"/> was found and unboxed to the given <typeparamref name="TValue"/> type; false otherwise</returns>
        bool TryGetValue<TValue>(string key, out TValue value);

        #endregion
    } // end interface IConfigurationProvider
} // end namespace
