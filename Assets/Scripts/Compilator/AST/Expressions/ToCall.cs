using System.Globalization;
using System.Runtime.CompilerServices;
using System;

public abstract class ToCall : ExpressionDSL<object>
{
    protected Token? Caller;
    protected ExpressionDSL? Called;
    public override bool Validation(){
        return Errors.Count == 0;
    }
    public override IDType Type => IDType.Object;
    public override CodeLocation Location { get => Caller.Location; protected set => throw new NotImplementedException(); } 
}
public class Method : ToCall
{
    public ExpressionDSL[]? Parameters;
    public Method(Token? token, ExpressionDSL? expression, ExpressionDSL[]? parameters){
        Parameters = parameters;
        Caller = token;
        Called = expression;
    }
    public override bool Validation() => throw new NotImplementedException();
    public override object? Implement()
    {
        throw new NotImplementedException();
    }
    public override string ToString() => Caller.Value + Called.ToString();
}

public class Property : ToCall
{
    public Property(ExpressionDSL called, Token caller){
        Called = called;
        Caller = caller;
    }
    public override IDType Type => Called.Type;
    public override bool Validation() => throw new NotImplementedException();

    public override object? Implement()
    {
        object called  = Called.Implement();
        Type type;
        if (called is string) type = typeof(string);
        else if (called is Int) type = typeof(Int);
        else if(called is ICard) type = typeof(ICard);
        //if(called is GameList) type = typeof(GameList);
        else type = typeof(object);

        if (type.GetProperty(Caller.Value) != null)
        {
            return type.GetProperty(Caller.Value).GetValue(called);
        }
        else {
            ErrorThrower.AddError($"Property not found at line: {Caller.Location.Line}, column: {Caller.Location.Column}");
            return null;
        }
    }
}