using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace ClashClient.Annotations {
    /// <summary>
    /// Type that contains helper methods to work with <see cref="JsonPropertyAttribute"/> instances and other serialization / deserialization operations.
    /// </summary>
    public static class JsonAnnotationHelper {
        #region --Functions--

        /// <summary>
        /// Attempts to determine the name of a property in JSON for the given <paramref name="property"/>.
        /// </summary>
        /// <param name="property">The <see cref="PropertyInfo"/> to load the JSON name for.</param>
        /// <returns>The name of the property in JSON, making use of any known attributes.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the given <paramref name="property"/> is null.</exception>
        public static string GetJsonNameFromProperty(PropertyInfo property) {
            if (property == null) {
                throw new ArgumentNullException(nameof(property), "No property provided to load a JSON name for.");
            }

            var returnValue = string.Empty;

            System.Collections.Generic.IEnumerable<JsonPropertyAttribute> jsonAttributes = property.GetCustomAttributes().Where(p => p is JsonPropertyAttribute).OfType<JsonPropertyAttribute>();

            if (jsonAttributes != null && jsonAttributes.Any()) {
                // If we have more than one, it's luck of the draw
                JsonPropertyAttribute attr = jsonAttributes.FirstOrDefault();
                returnValue = attr.PropertyName;
            } else {
                returnValue = property.Name;
            }

            return returnValue;
        } // end function GetJsonNameFromProperty

        #endregion
    } // end class JsonAnnotationHelper
} // end namespace
