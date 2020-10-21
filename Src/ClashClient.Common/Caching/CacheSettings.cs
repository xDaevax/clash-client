using System.Configuration;
using System.Reflection;
using ClashClient.Common.Configuration;
using log4net;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type used to load custom cache settings from configuration.
    /// </summary>
    public class CacheSettings : ICacheSettings {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region --Fields--

        private bool? _cachingEnabled;
        private CacheConfigurationSection _configSection;
        private readonly IConfigurationProvider _configurationProvider;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheSettings"/> class.
        /// </summary>
        /// <param name="configurationProvider">The <see cref="IConfigurationProvider"/> instance used to load configuration information.</param>
        public CacheSettings(IConfigurationProvider configurationProvider) {
            this._configurationProvider = configurationProvider;
            this._cachingEnabled = null;
        } // end default constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Loads the preference with details on the given <paramref name="preference"/>.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreference"/> to load.</param>
        /// <returns>A new instance derived from the <see cref="ICachePreferenceElement"/> type.</returns>
        public virtual ICachePreferenceElement LoadPreference(CachePreference preference) {
            return this.Section.Preferences[preference];
        } // end function LoadPreference

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets a value indicating whether or not caching is currently enabled.
        /// </summary>
        public virtual bool CachingEnabled {
            get {
                if (this._cachingEnabled == null) {
                    if (this.ConfigurationProvider.TryGetValue(CommonConfigurationKeys.CachingEnabledKey, out bool cacheEnabled)) {
                        this._cachingEnabled = cacheEnabled;
                        Log.Debug("Application data caching enabled.");
                    } else {
                        this._cachingEnabled = false;
                        Log.Debug("Application data caching disabled.");
                    }
                }

                return this._cachingEnabled.Value;
            }
        } // end property CachingEnabled

        /// <summary>
        /// Gets the injected <see cref="IConfigurationProvider"/> instance used to load configuration information.
        /// </summary>
        protected IConfigurationProvider ConfigurationProvider => this._configurationProvider; // end property ConfigurationProvider

        /// <summary>
        /// Gets the custom configuration section from the web.config.  This is lazy-initialized on the first call.
        /// </summary>
        public CacheConfigurationSection Section {
            get {
                if (this._configSection == null) {
                    this._configSection = ConfigurationManager.GetSection("cacheConfigurationGroup/cacheConfiguration") as CacheConfigurationSection;
                }

                return this._configSection;
            }
        } // end property Section

        #endregion
    } // end class CacheSettings
} // end namespace
