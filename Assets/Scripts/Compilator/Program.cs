using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        string text = File.ReadAllText("Beluga.txt");
        Lexer lexer = new Lexer();
        List<Token> tokens = lexer.Tokenizer(text, "Beluga", new List<CompilingError>());

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Type}: {token.Value} at {token.Location.File}.txt in line: {token.Location.Line}, column: {token.Location.Column}");
        }
    }
}