using System;
using NUnit.Framework;

namespace ClashClient.TestHelpers {
    /// <summary>
    /// <see cref="EventArgs"/> type used to contain information about an event occurrence within a test and the current test context.
    /// </summary>
    public class TestEventArgs : EventArgs {
        #region --Fields--

        private string _name;

        #endregion

        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="TestEventArgs"/> class.
        /// </summary>
        public TestEventArgs()
            : base() {
            this._name = string.Empty;
        } // end default constructor

        #endregion

        #region --Properties--

        /// <summary>
        /// Gets or sets the descriptive name (not necessarily the code name) of the event.  This property will ignore setting null string values.
        /// </summary>
        public string Name {
            get => this._name;
            set {
                if (!string.IsNullOrEmpty(value)) {
                    this._name = value;
                }
            }
        } // end property Name

        /// <summary>
        /// Gets the context information for the currently executing test.
        /// </summary>
        public static TestContext TestContext => TestContext.CurrentContext; // end property TestContext

        #endregion
    } // end class TestEventArgs
} // end namespace
