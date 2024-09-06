using System.Linq.Expressions;

public abstract class ExpressionDSL : DSL
 {
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
public abstract class ExpressionDSL<T> : ExpressionDSL, IVisitable<T>{
    public virtual T Accept(IVisitor<T> visitor) => visitor.Visit(this);  
    public override bool Validation(){
        return Errors.Count == 0;
    }
}