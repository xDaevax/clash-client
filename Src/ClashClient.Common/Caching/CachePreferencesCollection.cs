using System;
using System.Configuration;

namespace ClashClient.Common.Caching {
    /// <summary>
    /// Type used to store a collection of cache preferences in configuration.
    /// </summary>
    public class CachePreferencesCollection : ConfigurationElementCollection {
        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="CachePreferencesCollection"/> class.
        /// </summary>
        public CachePreferencesCollection() {
        } // end default constructor

        #endregion

        #region --Methods--

        /// <summary>
        /// Adds the given <paramref name="preference"/> to the collection.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreferenceElement"/> to add.</param>
        public void Add(CachePreferenceElement preference) {
            this.BaseAdd(preference);
        } // end method Add

        /// <summary>
        /// Overrides the BaseAdd method and prevents it from throwin exceptions if the element already exists.
        /// </summary>
        /// <param name="element">The <see cref="ConfigurationElement"/> to add to the collection.</param>
        protected override void BaseAdd(ConfigurationElement element) {
            base.BaseAdd(element, false);
        } // end method BaseAdd

        /// <summary>
        /// Removes all elements from the configuration collection.
        /// </summary>
        public void Clear() {
            this.BaseClear();
        } // end method Clear

        /// <summary>
        /// Removes the given <paramref name="preference"/> element from the collection if it exists.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreferenceElement"/> to remove.</param>
        public void Remove(CachePreferenceElement preference) {
            if (this.BaseIndexOf(preference) >= 0) {
                this.BaseRemove(preference.Preference);
            }
        } // end overloaded method Remove

        /// <summary>
        /// Removes the element matching the given <paramref name="name" /> from the collection.
        /// </summary>
        /// <param name="name">The name of the item to remove.</param>
        public void Remove(string name) {
            this.BaseRemove(name);
        } // end overloaded method Remove

        /// <summary>
        /// Removes the element matching the given <paramref name="preference"/> from the collection.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreference"/> to remove.</param>
        public void Remove(CachePreference preference) {
            this.BaseRemove(preference);
        } // end overloaded method Remove

        /// <summary>
        /// Removes the configuration element at the given <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The index of the element to remove</param>
        public void RemoveAt(int index) {
            this.BaseRemoveAt(index);
        } // end method RemoveAt

        #endregion

        #region --Functions--

        /// <summary>
        /// Creates a new individual configuration element.
        /// </summary>
        /// <returns>A new <see cref="CachePreferenceElement"/> instance.</returns>
        protected override ConfigurationElement CreateNewElement() {
            return new CachePreferenceElement();
        } // end function CreateNewElement

        /// <summary>
        /// Returns the key of the given <paramref name="element"/>.
        /// </summary>
        /// <param name="element">The <see cref="ConfigurationElement"/> whose key is being retrieved.</param>
        /// <returns>The key of the given <paramref name="element"/>.</returns>
        protected override object GetElementKey(ConfigurationElement element) {
            return ((CachePreferenceElement)element).Preference;
        } // end function GetElementKey

        /// <summary>
        /// Gets the index of the given <paramref name="preference"/> in the collection.
        /// </summary>
        /// <param name="preference">The referenced <see cref="CachePreferenceElement"/> in the collection</param>
        /// <returns>An integer representing the given <paramref name="preference"/> element's position in the collection.</returns>
        public int IndexOf(CachePreferenceElement preference) {
            return this.BaseIndexOf(preference);
        } // end function IndexOf

        #endregion

        #region --Properties--

        /// <summary>
        /// The default property for this colleciton.
        /// </summary>
        /// <param name="index">The index of the configuration element to load.</param>
        /// <returns>The configuration element at the specified <paramref name="index"/>.</returns>
        public CachePreferenceElement this[int index] {
            get => (CachePreferenceElement)this.BaseGet(index);
            set {
                if (this.BaseGet(index) != null) {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        } // end default property

        /// <summary>
        /// Gets the configuration element with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the element being retrieved.</param>
        /// <returns>The configuration element with the given <paramref name="name"/>.</returns>
        public new CachePreferenceElement this[string name] {
            get => (CachePreferenceElement)this.BaseGet((CachePreference)Enum.Parse(typeof(CachePreference), name));
        } // end shadowed default string-based property

        /// <summary>
        /// Default property that gets the configuration element with the specified <paramref name="preference"/>.
        /// </summary>
        /// <param name="preference">The <see cref="CachePreference"/> to retrieve.</param>
        /// <returns>The configuration element with the given <paramref name="preference"/>.</returns>
        public CachePreferenceElement this[CachePreference preference] {
            get => (CachePreferenceElement)this.BaseGet(preference);
        } // end default enumeration-based property

        /// <summary>
        /// Gets the type of element collection.
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType {
            get => ConfigurationElementCollectionType.AddRemoveClearMap;
        } // end property CollectionType

        #endregion
    } // end class CachePreferencesCollection
} // end namespace
