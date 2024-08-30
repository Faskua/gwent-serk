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

public class GameContext : Expression
{
    public static GameContext? context;
    Board board;
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

public class Selector : Expression<object>
{
    Token selector;
    Expression Source { get;}
    Expression? Single { get;}
    Predicate predicate { get;}
    Expression Parent;
    public Selector(Token selector, Expression source, Predicate predicate, Expression parent, Expression? single = null){
        this.selector = selector;
        this.predicate = predicate;
        Source = source;
        Parent = parent;
        Single = single;
    }

    public override IDType Type => IDType.List;

    public override CodeLocation Location { get => selector.Location; protected set => throw new NotImplementedException(); }

    //TODO
    public override object Implement()
    {
        throw new NotImplementedException();
    }

    public override bool Validation()
    {
        Source.CheckType(IDType.String);
        if(!Source.Validation()) this.Errors.AddRange(Source.Errors);
        Single.CheckType(IDType.Boolean);
        if(!Single.Validation()) this.Errors.AddRange(Single.Errors);
        if(!predicate.Validation()) this.Errors.AddRange(predicate.Errors);
        
        if(Errors.Count != 0){
            string error = "";
            foreach (var item in Errors){
                error += item;
                error += "\n=";
            }
            throw new Exception(error);
        }
        return true;
    }
}

public class Predicate : Statement
{
    Token predi;
    Expression expression;
    Scope scope;
    public Predicate(Token token, Expression expr, Scope scope){
        predi = token;
        expression = expr;
        this.scope = scope;
    }
    public override CodeLocation Location => predi.Location;

    public override void Implement()
    {
        throw new NotImplementedException();
    }

    public override bool Validation(){
        if(expression.Type != IDType.Boolean) Errors.Add($"The Predicate at line: {predi.Location.Line},column: {predi.Location.Column} is not a boolean");
        return Errors.Count == 0;
    }
}

class Board
{

}

class GameList
{

}

class Faction
{

}

class Player
{

}