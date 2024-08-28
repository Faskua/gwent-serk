public class BinaryExpression : Expression
{
    public Expression Right { get;}
    public Expression Left { get;}
    public Token Operation { get;}
    public override CodeLocation Location { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public override IDType Type => throw new NotImplementedException();

    public BinaryExpression(Expression right, Expression left, Token op){
        Right = right;
        Left = left;
        Operation = op;
    }
    //TODO queda hacer todo el tema de la semantica de las expresiones binarias
    public override void Validation(IScope scope,out List<string> error)
    {
        throw new NotImplementedException();
    }
    public override object? Implement()
    {
        throw new NotImplementedException();
    }
}