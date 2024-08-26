using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string text = File.ReadAllText("Beluga.txt");
        Lexer lexer = new Lexer();
        List<Token> tokens = lexer.Tokenize(text);

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Type}: {token.Value} in line: {token.Location.Line}, column: {token.Location.Column}");
        }
    }
}