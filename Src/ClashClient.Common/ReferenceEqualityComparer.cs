using System.Collections.Generic;

namespace ClashClient.Common {
    /// <summary>
    /// Type that is capable of performing equality operations on any reference type.
    /// </summary>
    public class ReferenceEqualityComparer : EqualityComparer<object> {
        #region --Functions--

        /// <summary>
        /// Compares both <paramref name="x"/> and <paramref name="y"/> to eachother by reference and indicates whether the instances are equal.
        /// </summary>
        /// <param name="x">The instance to compare to.</param>
        /// <param name="y">The instance being compared.</param>
        /// <returns>true if <paramref name="x"/> and <paramref name="y"/> are referentially equal to one another.</returns>
        public override bool Equals(object x, object y) {
            return ReferenceEquals(x, y);
        } // end function Equals

        /// <summary>
        /// Safely loads the hash-code of the given <paramref name="obj"/> or 0 if the parameter is null.
        /// </summary>
        /// <param name="obj">The instance the hash-code is being loaded for.</param>
        /// <returns>A numeric hash-code for the given <paramref name="obj"/> or 0 if the object is null.</returns>
        public override int GetHashCode(object obj) {
            if (obj == null) {
                return 0;
            }

            return obj.GetHashCode();
        } // end function GetHashCode

        #endregion
    } // end class ReferenceEqualityComparer
} // end namespace
