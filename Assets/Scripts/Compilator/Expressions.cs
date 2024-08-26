using System.Linq.Expressions;

public abstract class Expression : Instruction
 {
//     public abstract void Validation(IScope scope);
    public abstract object? Evaluate();
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
    //TODO queda hacer todo el tema de la semantica de las expresiones binarias
    public override void Validation(IScope scope)
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

    public override object Implement(IimplementScope scope)
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
    public override void Validation(IScope scope)
    { //es una unaria, deberia ser un numero
        Id.CheckType(scope, IDType.Number);
        Id.Validation(scope);
    }
    //TODO: no estoy muy enterado de como funcionaria el evaluate en las unary
    public override object? Evaluate()
    {
        return null; //??
    }
    public override IDType Type(IScope scope)
    {
        return Id.Type(scope);
    }

    public override object Implement(IimplementScope scope)
    {
        int value = (int)(Id.Implement(scope));
        throw new NotImplementedException();
    }
}

public class LiteralExpression : Expression
{
    public Token Value { get;}
    
    public LiteralExpression(Token value){
        Value = value;
    }
    public override void Validation(IScope scope)
    {
        var type = Value.Type;
        //como es un literal, solo estan esas opciones
        if (type == TokenType.Number || type == TokenType.Text || type == TokenType.Boolean || scope.CheckDefinition(Value.Value)) return;
        
        throw new Exception();
    }
    public override object Evaluate()
    {
        if(Value.Type is TokenType.String){
            return Value.Value[1..^1]; //para quitar las ""
        }
        if(Value.Type is TokenType.Int) return int.Parse(Value.Value);
        if(Value.Value == "false") return false;
        return true;
    }

    public override IDType Type(IScope scope)
    {
        List<TokenType> types= [TokenType.Name, TokenType.Power, TokenType.Faction, TokenType.Type];
        if( scope != null && (types.Contains(Value.Type) || Value.Type is TokenType.Identifier)){
            //TODO deberia hacer un diccionario para guardar los tipos como handofplayer y eso para verificarlo aqui
            return scope.GetIdType(this.Value.Value);
        }

        Dictionary<TokenType, IDType> output = new(){
            {TokenType.Number, IDType.Number},
            {TokenType.Text, IDType.String},
            {TokenType.Boolean, IDType.Boolean}
        };
        return output[Value.Type];
    }

    public override object Implement(IimplementScope scope)
    {
        TokenType Type = Value.Type;
        switch (Type){
            case TokenType.Int:
                int output = int.Parse(Value.Value);
                return output;
            case TokenType.String:
                return Value.Value[1..^1]; //las ""
            case TokenType.Identifier: //obtener el valor de  la variable, no el nombre de ella
                return scope.Value(Value.Value);
        }
        if( Value.Value == "false") return false; //Para los booleanos 
        else return  true;
    }
}