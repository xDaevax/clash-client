namespace ClashClient.TestHelpers {
    /// <summary>
    /// Delegate method used for event delegation for testing events.
    /// </summary>
    /// <param name="sender">The instance that raised the event.</param>
    /// <param name="e">The <see cref="TestEventArgs"/> associated with the event.</param>
    public delegate void TestEventHandler(object sender, TestEventArgs e);
} // end namespace
