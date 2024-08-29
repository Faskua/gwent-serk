public class Enunciation : Statement
{
    protected IScope Scope;
    public Expression Value;
    public Token Name;
    public Token Operation;
    public Enunciation(Token name, IScope scope = null, Expression value = null, Token operation = null){
        Scope = scope;
        Value = value;
        Name = name;
        Operation = operation;
        this.Implement();
    }
    public override string ToString() => $"{Name.Value} {Operation.Value} {Value.ToString()}";
    public override CodeLocation Location { get => Operation != null ? Operation.Location : Name.Location; }

    public override void Implement()
    {
        try{
            switch (Operation.Type)
            {
                case TokenType.Assignation:
                    Scope.Define(Name.Value, Value);
                    break;
                case TokenType.PlusEqual:
                    Scope.Define(Name.Value, new NumericalBinary(Value, Scope.GetExp(Name.Value), new Token(Operation, "+")));
                    break;
                case TokenType.MinusEqual:
                    Scope.Define(Name.Value, new NumericalBinary(Value, Scope.GetExp(Name.Value), new Token(Operation, "-")));
                    break;
                case TokenType.Increase:
                    UnaryVal increase = new UnaryVal(new Token(TokenType.Int, "1", new CodeLocation(Operation.Location.Line, Operation.Location.Column)));
                    Scope.Define(Name.Value, new NumericalBinary(increase, Scope.GetExp(Name.Value), new Token(Operation, "+")));
                    break;
                case TokenType.Decrease:
                    UnaryVal decrease = new UnaryVal(new Token(TokenType.Int, "1", new CodeLocation(Operation.Location.Line, Operation.Location.Column)));
                    Scope.Define(Name.Value, new NumericalBinary(decrease, Scope.GetExp(Name.Value), new Token(Operation, "-")));
                    break;
                default:
                    throw new Exception($"Invalid enunciation at line: {Operation.Location.Line}, column: {Operation.Location.Column}");
            }
        }
        catch(NullReferenceException){

        }
    }
    public Expression ReceiveValue(){
        this.Implement();
        return Scope.GetExp(Name.Value);
    }

    public override bool Validation()
    {
        if(Value != null && !Value.Validation()){
            this.Errors.AddRange(Value.Errors);
            return false;
        }
        else if(Scope.GetExp(Name.Value) != null && !Value.Validation()){
            this.Errors.AddRange(Value.Errors);
            return false;
        }
        return true;
    }
    public IDType Type { get => Value != null ? Value.Type : Scope.GetExp(Name.Value).Type; }
}

public class EnunBlock : Statement
{
    List<Statement> Statements = [];    
    public EnunBlock(List<Statement> statements){ Statements = statements;}
    public override CodeLocation Location => throw new NotImplementedException();

    public override bool Validation(){
        foreach(Statement statement in Statements){
            if(!statement.Validation()) this.Errors.AddRange(statement.Errors);
        }
        return this.Errors.Count == 0;
    }

    public override void Implement()
    {
        foreach(Statement statement in Statements){
            statement.Implement();
        }
    }
}