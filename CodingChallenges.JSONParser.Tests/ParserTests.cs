namespace CodingChallenges.JSONParser.Tests
{
    public class ParserTests
    {
        [Test]
        public void IsValid_ForEmptyObject_ReturnsTrue()
        {
            var parser = new Parser();

            var isValid = parser.IsValidJSON("{}");

            Assert.True(isValid);
        }

        [Test]
        public void IsValidJSON_ForMissingClosingBracket_ReturnsFalse()
        {
            var parser = new Parser();

            var isValid = parser.IsValidJSON("{");

            Assert.False(isValid);
        }

        [Test]
        public void IsValidJSON_ForMissingOpeningBracket_ReturnsFalse()
        {
            var parser = new Parser();

            var isValid = parser.IsValidJSON("}");

            Assert.False(isValid);
        }

        [Test]
        public void IsValidJson_ForEmptyString_ReturnsFalse()
        {
            var parser = new Parser();

            var isValid = parser.IsValidJSON("");

            Assert.False(isValid);
        }
    }
}
