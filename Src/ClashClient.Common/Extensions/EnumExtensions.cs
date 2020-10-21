using System;
using System.Linq;
using System.Runtime.Serialization;

namespace ClashClient.Common.Extensions {
    /// <summary>
    /// Type that provides extension methods for enumeration types.
    /// </summary>
    public static class EnumExtensions {
        #region --Functions--

        /// <summary>
        /// Attempts to load the <see cref="EnumMemberAttribute.Value"/> for the enumeration value or the string form of the enumeration if none is defined.
        /// </summary>
        /// <param name="enum">The enumeration being extended.</param>
        /// <returns>The value for the enumeration member attribute or the name of the enumeration as a string.</returns>
        public static string ToEnumMemberAttributeValue(this Enum @enum) {
            EnumMemberAttribute attribute = @enum?.GetType().GetMember(@enum.ToString()).FirstOrDefault()?.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();
            string returnValue;
            if (attribute == null) {
                returnValue = @enum?.ToString();
            } else {
                returnValue = attribute.Value;
            }

            return returnValue;
        } // end function ToEnumMemberAttributeValue

        #endregion
    } // end class EnumExtensions
} // end namespace
