namespace CodingChallenges.JSONParser
{
    public class Lexer
    {
        public List<Token> Tokenise(string jsonString)
        {
            var tokens = new List<Token>();
            foreach (var character in jsonString)
            {
                if (character == '{')
                {
                    tokens.Add(new Token(TokenType.OpenCurlyBracket, character));
                }
                else if (character == '}')
                {
                    tokens.Add(new Token(TokenType.CloseCurlyBracket, character));
                }
            }

            return tokens;
        }
    }
}
