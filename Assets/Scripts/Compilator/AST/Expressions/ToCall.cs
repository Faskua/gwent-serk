using System.Globalization;
using System.Runtime.CompilerServices;

public abstract class ToCall : Expression<object>
{
    protected Token? Caller;
    protected Expression? Called;
    public override bool Validation(){
        return Errors.Count == 0;
    }
    public override IDType Type => IDType.Object;
    public override CodeLocation Location { get => Caller.Location; protected set => throw new NotImplementedException(); } 
}
public class Method : ToCall
{
    public Expression[] Parameters;
    public Method(Expression[] parameters, Token? token, Expression? expression){
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
    public Property(Expression called, Token caller){
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
        else if(called is Card) type = typeof(Card);
        //if(called is GameList) type = typeof(GameList);
        else type = typeof(object);

        if (type.GetProperty(Caller.Value) != null)
        {
            return type.GetProperty(Caller.Value).GetValue(called);
        }
        else throw new Exception($"Property not found at line: {Caller.Location.Line}, column: {Caller.Location.Column}");
    }
}