namespace GBUtils.Test.Extension
{
    using GBUtils.Extension;
    using GBUtils.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void WithFormattedString()
        {
            // Arrange
            string source = "Hey {0}, this is {1} work";
            string expected = "Hey dude, this is great work";

            // Act
            string target = source.With("dude", "great");

            // Assert
            Assert.AreEqual(expected, target);
        }
    }
}