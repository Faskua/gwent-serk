using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Transactions;

public abstract class BinaryExpression<T> : Expression<T>
{
    protected Expression Left { get; set;}
    protected Expression Right { get; set;}
    protected Token Operation { get; set;}
    public override CodeLocation Location { get => Operation.Location; protected set => throw new NotImplementedException(); }

    public override string ToString() => $"{Left.ToString()} {Operation.Value} {Right.ToString()}";

    public BinaryExpression(Expression right, Expression left, Token op){
        Right = right;
        Left = left;
        Operation = op;
    }
    public override bool Validation(out List<string> error)
    {
        error = [];
        if(!this.Validation(out List<string> errors)){
            foreach (var item in errors){
                error.Add(item);
            }
            return false;
        }
        else return true;
    }
}

public class NumericalBinary : BinaryExpression<Int> //las operaciones binarias
{
    List<TokenType> operations = new List<TokenType> {TokenType.Plus, TokenType.Minus, TokenType.Multip, TokenType.Pow, TokenType.Division};
    public NumericalBinary(Expression right, Expression left, Token op) : base(right, left, op){}
    public override IDType Type => IDType.Number;

    public override bool Validation(out List<string> error)
    {
        error = [];
        if(!operations.Contains(Operation.Type)) error.Add($"Unexpected operation in line: {Location.Line}, column: {Location.Column}");
        if(!Left.CheckType(IDType.Number)) error.Add($"The expression at line: {Left.Location.Line}, column: {Left.Location.Column} is not a number");
        if(!Right.CheckType(IDType.Number)) error.Add($"The expression at line: {Right.Location.Line}, column: {Right.Location.Column} is not a number");
        return error.Count == 0;
    }

    public override object? Implement()
    {
        try{
            switch (Operation.Type)
            {
                case TokenType.Plus:
                    return ((Int)Left.Implement()).Plus((Int)Right.Implement());
                case TokenType.Minus:
                    return ((Int)Left.Implement()).Minus((Int)Right.Implement());
                case TokenType.Multip:
                    return ((Int)Left.Implement()).Multip((Int)Right.Implement());
                case TokenType.Pow:
                    return ((Int)Left.Implement()).Pow((Int)Right.Implement());
                case TokenType.Division:
                    return ((Int)Left.Implement()).Division((Int)Right.Implement());
                default:
                    return null;
            }
        }
        catch(Exception){
            throw new Exception($"Unrecognized Operation at line: {Location.Line}, column: {Location.Column}");
        }
    }
}

public class BooleanBinary : BinaryExpression<bool>
{
    private List<TokenType> operations = new List<TokenType> {TokenType.And, TokenType.Or};
    public BooleanBinary(Expression right, Expression left, Token op) : base(right, left, op){}
    public override IDType Type => IDType.Boolean;
    public override bool Validation( out List<string> error){
        error = [];
        if(!operations.Contains(Operation.Type)) error.Add($"Unexpected operator at line: {Location.Line}, column: {Location.Column}");
        if(!Left.CheckType(IDType.Boolean)) error.Add($"The expression at line: {Left.Location.Line}, column: {Left.Location.Column} is not a boolean expression");
        if(!Right.CheckType(IDType.Boolean)) error.Add($"The expression at line: {Right.Location.Line}, column: {Right.Location.Column} is not a boolean expression");
        return error.Count == 0;
    }

    public override object? Implement(){
        try{
            switch(Operation.Type){
                case TokenType.Or:
                    return (bool)Left.Implement() || (bool)Right.Implement();
                case TokenType.And:
                    return (bool)Left.Implement() && (bool)Right.Implement();
                default: 
                    return null;
            }
        }
        catch(Exception){
            throw new Exception($"Unrecognized Operation at line: {Location.Line}, column: {Location.Column}");
        }
    }
}

public class BooleanExpression : BinaryExpression<bool>
{
    List<TokenType> operations = new List<TokenType> {  TokenType.Greater, TokenType.Less, 
                                                        TokenType.GreaterEqual, TokenType.LessEqual,
                                                        TokenType.Equals, TokenType.NotEquals};
    public BooleanExpression(Expression right, Expression left, Token op) : base(right, left, op){}
    public override bool Accept(IVisitor<bool> visitor){
        return base.Accept(visitor);
    }
    public override IDType Type => IDType.Boolean;
    public override bool Validation(out List<string> error)
    {
        error = [];
        if(!operations.Contains(Operation.Type)) error.Add($"Unexpected operator at line: {Location.Line}, column: {Location.Column}");    
        if(!Right.CheckType(IDType.Number)) error.Add($"A number was expected at line: {Right.Location.Line}, column: {Right.Location.Column}");
        if(!Left.CheckType(IDType.Number)) error.Add($"A number was expected at line: {Left.Location.Line}, column: {Left.Location.Column}");
        return error.Count == 0;
    }

    public override object? Implement()
    {
        try{
            switch(Operation.Type){
                case TokenType.Greater:
                    return ((Int)Left.Implement()).Value > ((Int)Right.Implement()).Value;
                case TokenType.Less:
                    return ((Int)Left.Implement()).Value < ((Int)Right.Implement()).Value;
                case TokenType.GreaterEqual:
                    return ((Int)Left.Implement()).Value >= ((Int)Right.Implement()).Value;
                case TokenType.LessEqual:
                    return ((Int)Left.Implement()).Value <= ((Int)Right.Implement()).Value;
                case TokenType.Equals:
                    return Left.Implement().Equals(Right.Implement());
                case TokenType.NotEquals:
                    return !Left.Implement().Equals(Right.Implement());
                default:
                    return null;
            }
        }
        catch(Exception){
            throw new Exception($"Unrecognized Operation at line: {Location.Line}, column: {Location.Column}");
        }
    }
}

public class StringBinary : BinaryExpression<string>
{
    public StringBinary(Expression right, Expression left, Token op) : base(right, left, op){}
    public override IDType Type => IDType.String;
    List<TokenType> operations = new List<TokenType> {TokenType.Concat, TokenType.SpaceConcat};

    public override bool Validation(out List<string> error){
        error = [];
        if(!operations.Contains(Operation.Type)) error.Add($"Unexpected operation at line: {Location.Line}, column: {Location.Column}");
        if(!Left.CheckType(IDType.String)) error.Add($"A string was expected at line: {Left.Location.Line}, column: {Left.Location.Column}");
        if(!Right.CheckType(IDType.String)) error.Add($"A string was expected at line: {Right.Location.Line}, column: {Right.Location.Column}");
        return error.Count == 0;
    }
    public override object? Implement(){
        try{
            if(Operation.Type is TokenType.Concat)
                return (string)Left.Implement() + (string)Right.Implement();
            else if(Operation.Type is TokenType.SpaceConcat) 
                return $"{(string)Left.Implement()} {(string)Right.Implement()}";
                else return null;
        }
        catch{
            throw new Exception($"Unrecognized Operation at line: {Location.Line}, column: {Location.Column}");
        }
    }
}