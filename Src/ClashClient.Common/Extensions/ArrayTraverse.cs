using System;

namespace ClashClient.Common.Extensions {
    /// <summary>
    /// Type that allows multi-dimensional and jagged arrays to be traversed easily.
    /// </summary>
    public class ArrayTraverse {
        #region --Fields--

        private readonly int[] _maxLenths;
        private int[] _position;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTraverse"/> class.  This is a NON-TRADITIONAL constructor and therefore
        /// should not be used as an exaple when creating new types.  This constructor contains a fair amount of logic as the entire class is
        /// created to encapsulate a very specific use-case for creating deep copies of arrays.
        /// </summary>
        /// <param name="array">The array being traversed for a deep-copy.</param>
        public ArrayTraverse(Array array) {
            this._maxLenths = new int[array?.Rank ?? 0];
            for (var i = 0; i < array.Rank; i++) {
                this._maxLenths[i] = array.GetLength(i) - 1;
            }

            this.Position = new int[array.Rank];
        } // end constructor

        #endregion

        #region --Functions--

        /// <summary>
        /// Builds out the position property and returns a value indicating whether the position was incremented or padded.
        /// </summary>
        /// <returns>true if the position was incremented; false otherwise</returns>
        public bool Step() {
            for (var i = 0; i < this.Position.Length; i++) {
                if (this.Position[i] < this._maxLenths[i]) {
                    this.Position[i]++;
                    for (var j = 0; j < i; j++) {
                        this.Position[j] = 0;
                    }

                    return true;
                }
            }

            return false;
        } // end function Step

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets values used to store an array of positions that point to indices in an array.
        /// </summary>
        public int[] Position {
            get => this._position;
            set => this._position = value;
        } // end property Positiom

        #endregion
    } // end class ArrayTraverse
} // end namespace
