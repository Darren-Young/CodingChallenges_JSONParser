namespace CodingChallenges.JSONParser
{
    public class Lexer
    {
        private int _currentPosition;

        public List<Token> Tokenise(string jsonString)
        {
            _currentPosition = 0;

            var tokens = new List<Token>();
            var characters = jsonString.ToCharArray();

            while (_currentPosition < jsonString.Length)
            {
                var character = jsonString[_currentPosition];
                switch (character)
                {
                    case '{':
                        tokens.Add(new Token(TokenType.OpenCurlyBracket, character));
                        ++_currentPosition;
                        break;
                    case '}':
                        tokens.Add(new Token(TokenType.CloseCurlyBracket, character));
                        ++_currentPosition;
                        break;
                    case '"':
                        var tokenValue = GetStringToken(jsonString);
                        tokens.Add(new Token(TokenType.StringLiteral, tokenValue));
                        break;
                    case ':':
                        tokens.Add(new Token(TokenType.Colon, character));
                        ++_currentPosition;
                        break;
                    case ',':
                        tokens.Add(new Token(TokenType.Comma, character));
                        ++_currentPosition;
                        break;
                    default:
                        throw new FormatException($"Unexpected character in position {_currentPosition}");
                }
            }

            return tokens;
        }

        private string GetStringToken(string jsonString)
        {
            var operationPosition = _currentPosition + 1;
            while (operationPosition < jsonString.Count() && jsonString[operationPosition] != '"')
            {
                ++operationPosition;
            }

            if (operationPosition >= jsonString.Count())
            {
                throw new FormatException($"String not closed correctly at position {_currentPosition}");
            }

            var value = jsonString.Substring(_currentPosition + 1, operationPosition - _currentPosition - 1);

            _currentPosition = operationPosition + 1;

            return value;
        }
    }
}
