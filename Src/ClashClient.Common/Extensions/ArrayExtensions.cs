using System;

namespace ClashClient.Common.Extensions {
    /// <summary>
    /// Contains extension methods for arrays.  Additions to this type should be made with caution.
    /// </summary>
    public static class ArrayExtensions {
        #region --Functions--

        /// <summary>
        /// Method that allows jagged arrays and multi-dimensional arrays to be included in deep-copy operations.
        /// </summary>
        /// <param name="array">The array being extended.</param>
        /// <param name="action">The action to perform for each position within the array.</param>
        public static void ForEach(this Array array, Action<Array, int[]> action) {
            if (array?.LongLength == 0) {
                return;
            }

            var walker = new ArrayTraverse(array);
            do {
                action?.Invoke(array, walker.Position);
            } while (walker.Step());
        } // end function ForEach

        #endregion
    } // end class ArrayExtensions
} // end namespace
