namespace GBUtils.Test.Extension
{
    using GBUtils.Extension;
    using GBUtils.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void TestWhitelisting()
        {

            Assert.AreEqual("", "".WhitelistFiltered());
            Assert.AreEqual("   ", "   ".WhitelistFiltered());
            Assert.AreEqual("áàâéèêíìîóòôúùûäö., -", "áàâéèêíìîóòôúùûäö., -".WhitelistFiltered());
            Assert.AreEqual("ABCD", "A#$%^B<>&&;C;:'D".WhitelistFiltered());
            Assert.AreEqual("0123456789", "0123456789".WhitelistFiltered());
        }

        [TestMethod]
        public void FirstCharacterUppercaseRestLowercase()
        {
            // Arrange
            string source = "ThisIsCamelCased";
            string expected = "Thisiscamelcased";

            // Act
            string target = source.FirstCharacterUppercaseRestLowercase();

            // Assert
            Assert.AreEqual(expected, target);
        }

        [TestMethod]
        public void FirstCharacterUppercase()
        {
            // Arrange
            string source = "thisIsCamelCased";
            string expected = "ThisIsCamelCased";

            // Act
            string target = source.FirstCharacterUppercase();

            // Assert
            Assert.AreEqual(expected, target);
        }

        [TestMethod]
        public void FirstCharacterUppercaseWithIJ()
        {
            // Arrange
            string source = "ijskraam";
            string expected = "IJskraam";

            // Act
            string target = source.FirstCharacterUppercase();

            // Assert
            Assert.AreEqual(expected, target);
        }

        [TestMethod]
        public void Right()
        {
            Assert.AreEqual("ude", "Hey Dude".Right(3));
            Assert.AreEqual("Hey Dude", "Hey Dude".Right(300));
        }

        [TestMethod]
        public void Left()
        {
            Assert.AreEqual("Hey", "Hey Dude".Left(3));
            Assert.AreEqual("Hey Dude", "Hey Dude".Left(300));
        }
    }
}