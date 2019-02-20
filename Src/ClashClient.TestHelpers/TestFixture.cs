using NUnit.Framework;

namespace ClashClient.TestHelpers {
    /// <summary>
    /// Base type that provides a general execution pipeline for an automated test.  It is recommended that all NUnit tests
    /// derive from this base (or a more derived version of this base) to promote test uniformity and consistency.
    /// </summary>
    public abstract class TestFixture {
        #region --Constructors--

        /// <summary>
        /// Initializes a new instance of the <see cref="TestFixture"/> class.
        /// </summary>
        protected TestFixture() {
            this.PreSetup += this.OnPreSetup;
            this.PostSetup += this.OnPostSetup;
        } // end default constructor

        #endregion

        #region --Event Handlers--

        /// <summary>
        /// Handles Pre-setup operations for the test.
        /// </summary>
        /// <param name="sender">The fixture performing test setup</param>
        /// <param name="e">The event args that give context to setup</param>
        protected virtual void OnPreSetup(object sender, TestEventArgs e) {
            TestContext.WriteLine(e.Name);
        } // end method OnPreSetup

        /// <summary>
        /// Handles Post-setup operations for the test.
        /// </summary>
        /// <param name="sender">The fixture performing test setup</param>
        /// <param name="e">The event args that give context to setup</param>
        protected virtual void OnPostSetup(object sender, TestEventArgs e) {
            TestContext.WriteLine(e.Name);
        } // end method OnPostSetup

        #endregion

        #region --Methods--

        /// <summary>
        /// Performs per-test initialization and test preparation.  This method is NOT marked virtual in order to maintain the integrity
        /// of the event registration and firing order.  Any test setup can occur in event handlers for the respective event.
        /// </summary>
        [SetUp]
        protected void Setup() {
            this.PreSetup?.Invoke(this, new TestEventArgs() { Name = "Pre-Setup" });

            this.PostSetup?.Invoke(this, new TestEventArgs() { Name = "Post-Setup" });
        } // end method Setup

        /// <summary>
        /// Performs per-test de-construction and cleanup.
        /// </summary>
        [TearDown]
        protected virtual void TearDown() {
        } // end method TearDown

        #endregion

        #region --Events--

        /// <summary>
        /// Event that fires before executing any pre-setup steps.
        /// </summary>
        public event TestEventHandler PreSetup;

        /// <summary>
        /// Event that fires after the setup operations have been completed.
        /// </summary>
        public event TestEventHandler PostSetup;

        #endregion
    } // end class TestFixture
} // end namespace
