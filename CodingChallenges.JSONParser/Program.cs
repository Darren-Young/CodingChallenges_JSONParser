using CodingChallenges.JSONParser;

var parser = new Parser();
var isValid = parser.IsValidJSON("{}");

Console.WriteLine(isValid ? "Valid JSON" : "Invalid JSON");

return isValid ? 0 : 1;
