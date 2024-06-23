namespace CodingChallenges.JSONParser
{
    public class Parser
    {
        private readonly Lexer _lexer;
        private int _currentLocation;

        public Parser()
        {
            _lexer = new Lexer();
        }

        public bool IsValidJSON(string jsonString)
        {
            _currentLocation = 0;

            var tokens = _lexer.Tokenise(jsonString);
            //todo: check first token is {
            return IsValidObject(tokens, 0);
        }

        private bool IsValidObject(List<Token> tokens, int currentPosition)
        {
            if (tokens.Count is 0) return false;
            if (_currentLocation == tokens.Count - 1) return false;

            ++currentPosition;
            while (currentPosition < tokens.Count)
            {
                var token = tokens[currentPosition];
                switch (token.TokenType)
                {
                    case TokenType.CloseCurlyBracket: return true;
                    case TokenType.StringLiteral:
                        // We have found a key...look ahead to validate expected pattern
                        var isValidKeyValuePair = IsValidKeyValuePair(tokens, currentPosition);
                        if (isValidKeyValuePair is false) return false;

                        currentPosition += 3;
                        break;
                    case TokenType.Comma:
                        var isValidComma = IsValidComma(tokens, currentPosition);
                        if (isValidComma is false) return false;

                        ++currentPosition;
                        break;
                    default: return false;
                }
            }

            return false;
        }

        private bool IsValidKeyValuePair(List<Token> tokens, int currentPosition)
        {
            if (currentPosition + 2 >= tokens.Count) return false;

            var expectedColon = tokens[currentPosition + 1];
            var expectedValue = tokens[currentPosition + 2];

            return expectedColon.TokenType is TokenType.Colon &&
                expectedValue.TokenType is TokenType.StringLiteral;
        }

        private bool IsValidComma(List<Token> tokens, int currentPosition)
        {
            var previousToken = tokens[currentPosition - 1];
            if (previousToken.TokenType is TokenType.Comma)
            {
                return false;
            }

            if (currentPosition == tokens.Count - 1)
            {
                return false;
            }

            var nextToken = tokens[currentPosition + 1];
            if (nextToken.TokenType is not TokenType.StringLiteral)
            {
                return false;
            }

            return true;
        }
    }
}
