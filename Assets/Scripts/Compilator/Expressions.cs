using System.Linq.Expressions;

public abstract class Expression
{
    public abstract void Validate(IScope scope);
    public abstract object Evaluate();
    public abstract IDType Type(IScope scope);
    //si no es tipo que necesita lanza un error
    public void CheckType(IScope scope, IDType needed){
        if(this.Type(scope) != needed) throw new Exception();
    }
}

public class BinaryExpression : Expression
{
    public Expression Right { get;}
    public Expression Left { get;}
    public Token Operation { get;}
    
    public BinaryExpression(Expression right, Expression left, Token op){
        Right = right;
        Left = left;
        Operation = op;
    }
    public override void Validate(IScope scope)
    {
        throw new NotImplementedException();
    }
    public override object Evaluate()
    {
        throw new NotImplementedException();
    }
    public override IDType Type(IScope scope)
    {
        throw new NotImplementedException();
    }
}

public class UnaryExpression : Expression
{
    public Expression Id { get;}
    public Token Operation { get;}
    public bool IsEnd { get;}

    public UnaryExpression(Expression id, Token op, bool end){
        Id = id;
        Operation = op;
        IsEnd = end;
    }
    public override void Validate(IScope scope)
    {
        if (Id is LiteralExpression LIT){
            //si es una expresion unaria tiene que tener un numero
            Id.CheckType(scope, IDType.Number);
            LIT.Validate(scope);
        }
        throw new Exception();
    }
    public override object Evaluate()
    {
        throw new NotImplementedException();
    }
    public override IDType Type(IScope scope)
    {
        return Id.Type(scope);
    }
}

public class LiteralExpression : Expression
{
    public Token Value { get;}
    
    public LiteralExpression(Token value){
        Value = value;
    }
    public override void Validate(IScope scope)
    {
        var type = Value.Type;
        //si no es un numero, string, booleano o no esta definido en el scope se lanza un error
        if (type == TokenType.Number || type == TokenType.Text || Value.Value == "true"
         || Value.Value == "false" || scope.IsDefined(Value.Value)) return;
        
        throw new Exception();
    }
    public override object Evaluate()
    {
        return Value.Value;
    }

    //Pendiente por vaerificar bien, solo tengo int, string y boolean
    public override IDType Type(IScope scope)
    {
        Dictionary<TokenType, IDType> output = new(){
            {TokenType.Number, IDType.Number},
            {TokenType.Text, IDType.Text},
            {TokenType.Boolean, IDType.Boolean}
        };
        return output[Value.Type];
    }
}