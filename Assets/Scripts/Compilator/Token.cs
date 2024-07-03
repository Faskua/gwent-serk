using System.Diagnostics.CodeAnalysis;

public enum TokenType
{
    Number,
    Text,
    Keyword,
    Identifier,
    Symbol,
    Unknwon,
}

public class CodeLocation
{
    public string File;
    public int Line;
    public int Column;

    public CodeLocation( string file, int line, int column)
    {
        File = file;
        Line = line;
        Column = column;
    }
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

public class TokenStream 
{
    List<Token> tokens;
    int position;

    public TokenStream(IEnumerable<Token> tokens)
    {
        this.tokens = new List<Token>(tokens);
        position = 0;
    }

    public int Position { get { return position; } }

    public bool End => position == tokens.Count-1;

    public void MoveNext(int k)
    {
        position += k;
    }

    public void MoveBack(int k)
    {
        position -= k;
    }

    public bool Next()
    {
        if (position < tokens.Count - 1)
        {
            position++;
        }

        return position < tokens.Count;
    }

    public bool Next( TokenType type )
    {
        if (position < tokens.Count-1 && LookAhead(1).Type == type)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool Next(string value)
    {            
        if (position < tokens.Count-1 && LookAhead(1).Value == value)
        {
            position++;
            return true;
        }

        return false;
    }

    public bool CanLookAhead(int k = 0)
    {
        return tokens.Count - position > k;
    }

    public Token LookAhead(int k = 0)
    {
        return tokens[position + k];
    }

    public Token InPosition(int k)
    {
        if (k > -1 && k < tokens.Count)
        {
            position ++;
            return tokens[k];
        }
        else throw new Exception("Index out of range");
    }
}