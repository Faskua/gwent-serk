using System.Transactions;
using System;
using System.Collections.Generic;

public abstract class UnaryExp<T> : ExpressionDSL<T>
{
    protected T Value;
    public override CodeLocation Location { get; protected set;}
    public override string ToString()=> Value.ToString();
    public override bool Validation(){
        return Errors.Count == 0;
    }
}

public class UnaryObj : UnaryExp<object>
{
    public UnaryObj(object value, CodeLocation location){
        Value = value;
        Location = location;
    }
    public override IDType Type{
        get{
            if(Value is int || Value is double) return IDType.Number;
            if(Value is string) return IDType.String;
            if(Value is ICard) return IDType.Card;
            //if(Value is List) return IDType.List;
            return IDType.Object;
        }
    }
    public override object? Implement() => Value;
}
public class UnaryOp : ExpressionDSL<object>
{
    public ExpressionDSL Id { get;}
    public Token Operation { get;}

    public UnaryOp(ExpressionDSL id, Token op){
        Id = id;
        Operation = op;
    }
    public override CodeLocation Location{
        get{ return Id.Location;}
        protected set{ Location = value;}
    }
    public override IDType Type => Id.Type;

    public override bool Validation()
    { 
        if(Id.CheckType(IDType.Number) || Id.CheckType(IDType.Boolean)) return true;
        else 
            Errors.Add($"Wrong us for expression at line: {Id.Location.Line}, column: {Id.Location.Column}");
            ErrorThrower.RangeError(Errors);
        return false;
    }
    public override object? Implement()
    {
        switch(Operation.Value){
            case "!":
                return !(bool)Id.Implement();
            case "-":
                return new Int(-((Int)Id.Implement()).Value);
            default:
                ErrorThrower.AddError($"Unrecognized operation at line: {Operation.Location.Line}, column: {Operation.Location.Column}");
                return null;

        }
    }
}

public class UnaryVal : UnaryExp<Token>
{
    public UnaryVal(Token token){
        Value = token;
        Location = token.Location;
    }

    public override object? Implement(){
        switch (Value.Type)
        {
            case TokenType.Int:
                return new Int(double.Parse(Value.Value));
            case TokenType.String:
                return Value.ToString();
            case TokenType.True:
                return true;
            case TokenType.False:
                return false; 
            default:
                ErrorThrower.AddError($"Unexpected Token at line: {Location.Line}, column: {Location.Column}");
                return null;
        }
    }
    public override IDType Type{
       get{
            switch(Value.Type){
                case TokenType.Int:
                    return IDType.Number;
                case TokenType.String:
                    return IDType.String;
                case TokenType.True:
                    return IDType.Boolean;
                case TokenType.False:
                    return IDType.Boolean;
                default:
                    ErrorThrower.AddError($"Unexpected Token at line: {Location.Line}, column: {Location.Column}");
                    return IDType.Object;
            }
       }
    }
}

public class UnaryToCall : UnaryExp<ToCall>
{
    public UnaryToCall(ToCall value){
        Value = value;
        Location = value.Location;
    }
    public override IDType Type => Value.Type;

    public override object? Implement() => Value.Implement();
}

//TODO: UnaryEnun para las Enunciations