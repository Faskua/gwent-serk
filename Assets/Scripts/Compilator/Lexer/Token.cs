using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Transactions;

public enum TokenType
{
    Int,     String,     
    Boolean, 
    Less,       Greater,
    LessEqual, GreaterEqual,  
    Assignation,    Semicolon,  
    Comma,  Colon,  
    Dot,    Symbol,
    If,   Identifier,
    For,        While,
    Else,   LBracket,   
    RBracket,   LParen,     
    RParen,     LCurlyB,
    RCurlyB,    Selector,

    Plus,   Minus,
    Multip, Division,
    Increase,   Decrease,
    PlusEqual, MinusEqual,
    Pow,


    Card,   Name,
    Type,   Faction,
    Range,  Power,
    Board,  Targets,
    And,    Or,
    Not,    Concat,
    SpaceConcat,     Equals,

    Effect,     Predicate, 
    PostAction, OnActivation,
    Action,     Params,
    Source,     Single,
    In,         Implication,
    EffParam,   Amount,



    Number,     Text,   Bool,

    Unknown
    
}

public enum IDType
{
    Number,
    String,
    Boolean,
    Card,
    Deck,
    Player,
    Targets,
    Predicate,
    Context, 
    Null
    
}

public class CodeLocation
{
    public int Line;
    public int Column;

    public CodeLocation(int line, int column)
    {
        Line = line;
        Column = column;
    }
}

public struct Variable
{
    public Expression? Value { get;}
    public IDType IDType { get;}
    public Variable(Expression? value, IDType idtype){
        Value = value;
        IDType = idtype;
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
    public static Dictionary<string, TokenType> Types = new Dictionary<string, TokenType>(){
        //Types
        {"true", TokenType.Boolean},
        {"false", TokenType.Boolean},
        {"Text", TokenType.Text},
        {"Number", TokenType.Number},
        {"Bool", TokenType.Bool},

        //Loop
        {"if", TokenType.If},
        {"else", TokenType.Else},
        {"for", TokenType.For},
        {"while", TokenType.While},

        //Reserved words for DSL
        {"card", TokenType.Card},
        {"Name", TokenType.Name},
        {"Type", TokenType.Type},
        {"Faction", TokenType.Faction},
        {"Range", TokenType.Range},
        {"Power", TokenType.Power},
        {"Board", TokenType.Board},
        {"targets", TokenType.Targets},
        {"effect", TokenType.Effect},
        {"Effect", TokenType.EffParam},
        {"Predicate", TokenType.Predicate},
        {"PostAction", TokenType.PostAction},
        {"OnActivation", TokenType.OnActivation},
        {"Action", TokenType.Action},
        {"Params", TokenType.Params},
        {"Source", TokenType.Source},
        {"Single", TokenType.Single},
        {"Selector", TokenType.Selector},
        {"in", TokenType.Text},
        {"Amount", TokenType.Amount},

        // Operators
        {">", TokenType.Greater},
        {"<", TokenType.Less},
        {">=", TokenType.GreaterEqual},
        {"<=", TokenType.LessEqual},
        {"=>", TokenType.Implication},
        {"+", TokenType.Plus},
        {"-", TokenType.Minus},
        {"*", TokenType.Multip},
        {"/", TokenType.Division},
        {"^", TokenType.Pow},
        {"++", TokenType.Increase},
        {"--", TokenType.Decrease},
        {"+=", TokenType.PlusEqual},
        {"-=", TokenType.MinusEqual},
        {"&&", TokenType.And},
        {"||", TokenType.Or},
        {"==", TokenType.Equals},
        {"!", TokenType.Not},
        {"@", TokenType.Concat},
        {"@@", TokenType.SpaceConcat},


        //Punctuation
        {"=", TokenType.Assignation},
        {";", TokenType.Semicolon},
        {",", TokenType.Comma},
        {":", TokenType.Colon},
        {".", TokenType.Dot},
        {"(", TokenType.LParen},
        {"[", TokenType.LBracket},
        {"{", TokenType.LCurlyB},
        {")", TokenType.RParen},
        {"]", TokenType.RBracket},
        {"}", TokenType.RCurlyB},
    };
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

    public void MoveNext(int k = 1)
    {
        position += k;
    }

    public void MoveBack(int k = 1)
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