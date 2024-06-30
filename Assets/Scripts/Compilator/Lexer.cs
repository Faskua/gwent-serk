using System.Text.RegularExpressions;

public class Lexer
{
    public static Regex tokenExpression = new Regex (
        @"(?<Keyword>\b(effect|Name|Params|Amount|Action|for|in|while|context|targets|card|type|Faction|Power|Range|OnActivation|Effect|Selector|Source|Single|Predicate|PostAction|false|true)\b)|
          (?<Symbol>[{}:,.=();=>\[\]@@-])|
          (?<Identifier>\b[a-zA-Z_][a-zA-Z0-9_]*\b)|
          (?<Text>""(?:[^""\\]|\\.)*"")|
          (?<Number>\b\d+(\.\d+)?\b)|
          (?<Whitespace>\s+)",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
    );

    public List<Token> Tokenizer(string input)
    {
        List<Token> tokens = [];
        MatchCollection matches = tokenExpression.Matches(input);
        foreach (var match in matches.ToList())
        {
            if (match.Groups["Symbol"].Success)
            {
                tokens.Add(new Token(TokenType.Symbol, match.Value));
            }
            if (match.Groups["Keyword"].Success)
            {
                tokens.Add(new Token(TokenType.Keyword, match.Value));
            }
            if (match.Groups["Identifier"].Success)
            {
                tokens.Add(new Token(TokenType.Identifier, match.Value));
            }
            if(match.Groups["Text"].Success)
            {
                tokens.Add(new Token(TokenType.Text, match.Value));
            }
            if(match.Groups["Number"].Success)
            {
                tokens.Add(new Token(TokenType.Number, match.Value));
            }
        }
        return tokens;
    }
}

public class Program
{
    public static void Main()
    {
        string text = File.ReadAllText("Beluga.txt");
        Lexer lexer = new Lexer();
        List<Token> tokens = lexer.Tokenizer(text);

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Type}: {token.Value}");
        }
    }
}