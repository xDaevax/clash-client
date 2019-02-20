using System;
using System.Collections.Generic;
using ClashClient.Net;
using ClashClient.TestHelpers;
using NUnit.Framework;

namespace ClashClient.Tests.Unit.Net {
    /// <summary>
    /// Fixture that contains unit tests for the <see cref="QueryStringFormatter"/> type.
    /// </summary>
    [TestFixture, Category("Unit"), Category("Net"), TestOf(typeof(QueryStringFormatter))]
    public class QueryStringFormatterFixture : TestFixture {
        #region --Tests--

        [Test, Category("Unit"), Category("Net")]
        [TestCase("23", 23)]
        [TestCase("Compound+String", "Compound String")]
        [TestCase("Complex%2cItem%7cHere", "Complex,Item|Here")]
        public void QueryStringFormatter_Format_GivenNameAndValue_ShouldReturnFormattedString(string expectedValue, object inputValue) {
            // ARRANGE
            var sut = new QueryStringFormatter();
            string expectedKey = "test";
            KeyValuePair<string, string> result;

            // ACT
            result = sut.Format("test", inputValue);

            // ASSERT
            Assert.AreEqual(expectedKey, result.Key, "The key was not formatted properly.");
            Assert.AreEqual(expectedValue, result.Value, "The value was not formatted properly.");
        } // end test

        [Test, Category("Unit"), Category("Net")]
        public void QueryStringFormatter_Format_GivenNullKey_ShouldThrowException() {
            // ARRANGE
            var sut = new QueryStringFormatter();

            // ACT

            // ASSERT
            Assert.Throws<ArgumentNullException>(() => sut.Format(null, "test"), "The method should have thrown an exception.");
        } // end test

        [Test, Category("Unit"), Category("Net")]
        public void QueryStringFormatter_Format_GivenNullValue_ShouldThrowException() {
            // ARRANGE
            var sut = new QueryStringFormatter();

            // ACT

            // ASSERT
            Assert.Throws<ArgumentNullException>(() => sut.Format("key", null), "The method should have thrown an exception.");
        } // end test

        [Test, Category("Unit"), Category("Net")]
        public void QueryStringFormatter_Format_GivenNullValueWithNullsAllowed_ShouldNotThrowException() {
            // ARRANGE
            var sut = new QueryStringFormatter();
            KeyValuePair<string, string> result;

            // ACT
            result = sut.Format("key", null, true);

            // ASSERT
            Assert.NotNull(result, "The method should have allowed a null value and built a result.");
        } // end test

        #endregion
    } // end class QueryStringFormatterFixture
} // end namespace
