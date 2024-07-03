using System.Text.RegularExpressions;

public class Lexer
{

    public static Regex tokenExpression = new Regex (
        @"(?<Keyword>\b(effect|Name|Params|Amount|Action|for|in|while|context|targets|card|type|Faction|Power|Range|OnActivation|Effect|Selector|Source|Single|Predicate|PostAction|false|true)\b)|
          (?<Symbol>[{}:,.=();=>\[\]@@-])|
          (?<Identifier>\b[a-zA-Z_][a-zA-Z0-9_]*\b)|
          (?<Text>""(?:[^""\\]|\\.)*"")|
          (?<Number>\b\d+(\.\d+)?\b)|
          (?<Whitespace>[\s\t]+)",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
    );

    public List<Token> Tokenizer(string input, string fileName, List<CompilingError> Erors)
    {
        List<Token> tokens = [];
        MatchCollection matches = tokenExpression.Matches(input);
        int Line = 1;
        int Column = 1;
        int Last = 0;
        foreach (var match in matches.ToList())
        {
            for (int i = Last; i < match.Index; i++)
            {
                if ( input[i] == '\n')
                {
                    Line += 1;
                    Column = 1;
                }
                Column += 1;
            }
            Last = match.Index;
            if (match.Groups["Symbol"].Success)
            {
                tokens.Add(new Token(TokenType.Symbol, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if (match.Groups["Keyword"].Success)
            {
                tokens.Add(new Token(TokenType.Keyword, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if (match.Groups["Identifier"].Success)
            {
                tokens.Add(new Token(TokenType.Identifier, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Text"].Success)
            {
                tokens.Add(new Token(TokenType.Text, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            if(match.Groups["Number"].Success)
            {
                tokens.Add(new Token(TokenType.Number, match.Value, new CodeLocation(fileName, Line, Column)));
            }
            
        }
        return tokens;
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         string text = File.ReadAllText("Beluga.txt");
//         Lexer lexer = new Lexer();
//         List<Token> tokens = lexer.Tokenizer(text, "Beluga", new List<CompilingError>());

//         foreach (var token in tokens)
//         {
//             Console.WriteLine($"{token.Type}: {token.Value} at {token.Location.File}.txt in line: {token.Location.Line}, column: {token.Location.Column}");
//         }
//     }
// }