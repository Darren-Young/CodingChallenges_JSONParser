namespace CodingChallenges.JSONParser.Tests
{
    public class Tests
    {
        [Test]
        public void Tokenise_WhenValidJSON_ReturnsExpectedNumberOfTokens()
        {
            var lexer = new Lexer();

            var tokens = lexer.Tokenise("{}");

            Assert.That(tokens.Count, Is.EqualTo(2));
        }

        [Test]
        public void Tokenise_WhenInvalidString_ThrowsException()
        {
            var lexer = new Lexer();

            Assert.Throws<FormatException>(() => lexer.Tokenise("{\"darren}"));
        }
    }
}