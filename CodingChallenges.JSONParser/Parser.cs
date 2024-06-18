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
            return IsValidObject(tokens);
        }

        private bool IsValidObject(List<Token> tokens) 
        {
            if (tokens.Count == 0) return false;
            if (_currentLocation == tokens.Count - 1) return false;

            var operationLocation = _currentLocation + 1;
            if (tokens[operationLocation].TokenType == TokenType.CloseCurlyBracket)
            {
                return true;
            }

            return false;
        }

    }
}
