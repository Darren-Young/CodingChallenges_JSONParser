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

        [Test]
        public void IsValidJoin_WithConsecutiveCommas_ReturnsFalse()
        {
            var parser = new Parser();
            var isValid = parser.IsValidJSON("{\"darren\":\"Young\",,\"Kailey\":\"Ashurst\"}");

            Assert.False(isValid);
        }

        [Test]
        public void IsValidJson_WithTrailingComma_ReturnsFalse()
        {
            var parser = new Parser();
            var isValid = parser.IsValidJSON("{\"darren\":\"Young\",,\"Kailey\":\"Ashurst\",}");

            Assert.False(isValid);
        }

        [Test]
        public void IsValidJson_WithValidJson_ReturnsTrue()
        {
            var parser = new Parser();
            var isValid = parser.IsValidJSON("{\"darren\":\"Young\",\"Kailey\":\"Ashurst\"}");

            Assert.True(isValid);
        }
    }
}
