using System.Configuration;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type used to represent a caching custom configuration section for data caching settings.
    /// </summary>
    public class CacheConfigurationSection : ConfigurationSection {
        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheConfigurationSection"/> class.
        /// </summary>
        public CacheConfigurationSection() {
            var preference = new CachePreferenceElement();
            this.Preferences.Add(preference);
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the collection of preferences for caching strategies.
        /// </summary>
        [ConfigurationProperty("preferences", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CachePreferencesCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public CachePreferencesCollection Preferences {
            get => (CachePreferencesCollection)base["preferences"];
            set => base["preferences"] = value;
        } // end property Preferences

        #endregion
    } // end class CacheConfigurationSection
} // end namespace
