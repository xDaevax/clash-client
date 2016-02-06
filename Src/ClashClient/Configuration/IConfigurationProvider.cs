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
        /// Returns a value indicating whether or not the given <paramref name="key"/> is present in the configurtation.
        /// </summary>
        /// <param name="key">The key of the value being checked.</param>
        /// <returns>true if the key is present in the configuration; false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="key"/> is empty.</exception>
        bool HasValue(string key);

        #endregion
    } // end interface IConfigurationProvider
} // end namespace
