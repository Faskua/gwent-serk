public enum TokenType
{
    Regex Number = new Regex("[0-9]*"),
    Regex Text = new Regex(),
    Keyword,
    Identifier,
    Symbol,
    Unknwon,
}

public class CodeLocation
{
    public string file;
    public int line;
    public int column;
}

public class Token
{
    public string Value {get ; private set; }
    public TokenType Type { get; private set; }
    public CodeLocation Location { get; private set; }

    public Token ( TokenType type, string value, CodeLocation location)
    {
        Value = value;
        Type = type;
        Location = location;
    }
}
