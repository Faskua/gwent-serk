public interface IEffect{
    Expression Name { get;}
    Dictionary<string, Expression> Params { get;}
    Statement Action{ get;}
    IEffect? PostAction { get;}
}