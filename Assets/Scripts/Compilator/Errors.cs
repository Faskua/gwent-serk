using System.Collections.Generic;
using Unity.VisualScripting;

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

public static class ErrorThrower
{
    static List<string> errors = new List<string>();
    public static void AddError(string error) => errors.Add(error);
    public static void RangeError(List<string> errorList) => ErrorThrower.errors.AddRange(errorList);
    public static void Reset() => errors.Clear();
    public static string ThrowNReset(){
        string Errors = "";
        foreach (string error in errors){
            Errors += error;
            Errors += "\n";
        }
        Reset();
        return Errors;
    }
}