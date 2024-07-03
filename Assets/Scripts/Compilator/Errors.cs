public enum ErrorType
{
    Invalid,
    Unknwon, 
    Expected, 
    None,
}

public class CompilingError
{
    public ErrorType Type { get; }
    public CodeLocation Location { get; }
    public string Argument { get; }

    public CompilingError(ErrorType type, CodeLocation location, string arg)
    {
        Type = type;
        Location = location;
        Argument = arg;
    }
}