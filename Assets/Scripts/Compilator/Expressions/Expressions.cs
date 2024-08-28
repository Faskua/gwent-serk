using System.Linq.Expressions;

public abstract class Expression : Instruction
 {
    public abstract CodeLocation Location{ get; protected set;}
    public abstract IDType Type { get;}
    //si no es tipo que necesita lanza un error
    public bool CheckType(IDType needed){
        if(Type != needed){
            return false;
        }
        return true;
    }

}
public interface IVisitor<T>{
    T Visit(IVisitable<T> visitable);
}
public interface IVisitable<T>{
    T Accept(IVisitor<T> visitor);
}
public abstract class Expression<T> : Expression, IVisitable<T>{
    public virtual T Accept(IVisitor<T> visitor) => visitor.Visit(this);  
    public override bool Validation(out List<string> errors){
        errors = [];
        return errors.Count == 0;
    }
}


// public class LiteralExpression : Expression
// {
//     public Token Value { get;}
    
//     public LiteralExpression(Token value){
//         Value = value;
//     }
//     public override void Validation(IScope scope)
//     {
//         var type = Value.Type;
//         //como es un literal, solo estan esas opciones
//         if (type == TokenType.Number || type == TokenType.Text || type == TokenType.Boolean || scope.CheckDefinition(Value.Value)) return;
        
//         throw new Exception();
//     }
//     public override object Evaluate()
//     {
//         if(Value.Type is TokenType.String){
//             return Value.Value[1..^1]; //para quitar las ""
//         }
//         if(Value.Type is TokenType.Int) return int.Parse(Value.Value);
//         if(Value.Value == "false") return false;
//         return true;
//     }

//     public override IDType Type(IScope scope)
//     {
//         List<TokenType> types= [TokenType.Name, TokenType.Power, TokenType.Faction, TokenType.Type];
//         if( scope != null && (types.Contains(Value.Type) || Value.Type is TokenType.Identifier)){
//             //TODO deberia hacer un diccionario para guardar los tipos como handofplayer y eso para verificarlo aqui
//             return scope.GetIdType(this.Value.Value);
//         }

//         Dictionary<TokenType, IDType> output = new(){
//             {TokenType.Number, IDType.Number},
//             {TokenType.Text, IDType.String},
//             {TokenType.Boolean, IDType.Boolean}
//         };
//         return output[Value.Type];
//     }

//     public override object Implement(IimplementScope scope)
//     {
//         TokenType Type = Value.Type;
//         switch (Type){
//             case TokenType.Int:
//                 int output = int.Parse(Value.Value);
//                 return output;
//             case TokenType.String:
//                 return Value.Value[1..^1]; //las ""
//             case TokenType.Identifier: //obtener el valor de  la variable, no el nombre de ella
//                 return scope.Value(Value.Value);
//         }
//         if( Value.Value == "false") return false; //Para los booleanos 
//         else return  true;
//     }
// }