using System.IO;
using ClashClient.TestHelpers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ClashClient.Tests.Unit {
    /// <summary>
    /// Fixture that contains unit tests for the <see cref="ErrorResponse"/> type.
    /// </summary>
    [TestFixture, Category("Unit"), TestOf(typeof(ErrorResponse))]
    public class ErrorResponseFixture : TestFixture {
        #region --Tests--

        [Test, Category("Unit")]
        public void ErrorResponse_Constructor_ShouldInitializeDefaults() {
            // ARRANGE
            ErrorResponse sut = null;

            // ACT
            sut = new ErrorResponse();

            // ASSERT
            Assert.NotNull(sut, "The constructor failed to initialize the class.");
            Assert.AreEqual(string.Empty, sut.Message, "The message should be an empty string by default.");
            Assert.AreEqual(string.Empty, sut.Reason, "The reason should be an empty string by default.");
        } // end test

        [Test, Category("Unit")]
        public void ErrorResponse_Deserialize_ShouldReadAlternatePropertyNames() {
            // ARRANGE
            var json = "{\"reason\":\"Test Reason\", \"message\":\"Test Message\"}";
            ErrorResponse sut = null;
            JsonSerializer ser;

            // ACT
            using (var sr = new StringReader(json)) {
                using (var reader = new JsonTextReader(sr)) {
                    ser = new JsonSerializer();
                    sut = ser.Deserialize<ErrorResponse>(reader);
                }
            }

            // ASSERT
            Assert.NotNull(sut, "The serializer should have created an instance of the class.");
            Assert.AreEqual("Test Reason", sut.Reason, "The property did not have the correct json property name for the reason.");
            Assert.AreEqual("Test Message", sut.Message, "The property did not have the correct json property name for the message.");
        } // end test

        #endregion
    } // end class ErrorResponseFixture
} // end namespace
