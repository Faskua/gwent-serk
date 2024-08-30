public class Action{
    Token Target { get; }
    Token Context { get; }
    public Statement Block { get; }

    public Action(Token target, Token context, Statement block){
        Target = target;
        Context = context;
        Block = block;
    }
}

public class Context : Expression
{
    public override IDType Type => throw new NotImplementedException();

    public override CodeLocation Location { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public override object? Implement()
    {
        throw new NotImplementedException();
    }

    public override bool Validation()
    {
        throw new NotImplementedException();
    }
}