using System;
using System.Configuration;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type that represents an individual preference setting for caching.
    /// </summary>
    public class CachePreferenceElement : ConfigurationElement, ICachePreferenceElement {
        #region --Properties--

        /// <summary>
        /// Gets or sets the caching preference setting.
        /// </summary>
        [ConfigurationProperty("preference", IsRequired = true, IsKey = true)]
        public CachePreference Preference {
            get => (CachePreference)Enum.Parse(typeof(CachePreference), string.Concat(this["preference"], string.Empty));
            set => this["preference"] = value;
        } // end property Preference

        /// <summary>
        /// Gets or sets the actual length of time for this preference.
        /// </summary>
        [ConfigurationProperty("duration", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int Duration {
            get => (int)this["duration"];
            set => this["duration"] = value;
        } // end property Duration

        #endregion
    } // end class CachePreferenceElement
} // end namespace
