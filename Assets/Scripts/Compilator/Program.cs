using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static void Main()
    {
        string text = File.ReadAllText("Beluga.txt");
        Lexxer lexer = new Lexxer();
        List<Token> tokens = lexer.Tokenize(text);

        foreach (var token in tokens)
        {
            Console.WriteLine($"{token.Type}: {token.Value} in line: {token.Location.Line}, column: {token.Location.Column}");
        }
    }
}