using System;
using System.Collections.Generic;
public class IF : Statement
{
    Statement Instructions;
    ExpressionDSL Condition;
    Statement? Else;
    CodeLocation location;
    public IF(Statement instructions, ExpressionDSL booleanexp, CodeLocation loc, Statement? Else = null){
        Instructions = instructions;
        Condition = booleanexp;
        location = loc;
        this.Else = Else;
    }
    public override CodeLocation Location => location;

    public override void Implement(){
        if(Condition.Implement() is bool boolean && boolean) Instructions.Implement();
    }

    public override bool Validation(){
        bool isvalid = Instructions.Validation();
        if(!isvalid) this.Errors.AddRange(Instructions.Errors);
        if ( Else != null){
            isvalid = isvalid && Else.Validation();
            this.Errors.AddRange(Else.Errors);
        }
        if (!Condition.CheckType(IDType.Boolean)){
            this.Errors.Add($"A boolean expressions is expected at line: {Condition.Location.Line}, column: {Condition.Location.Column}");
            return false;
        }
        else if(!Condition.Validation()){
            this.Errors.AddRange(Condition.Errors);
            return false;
        }
        return isvalid;
    }
}
public class While : Statement
{
    Statement Instructions { get;}
    ExpressionDSL Condition { get;}
    CodeLocation location;

    public override CodeLocation Location => location;

    public While(Statement instruc, ExpressionDSL condit, CodeLocation loc){
        Instructions = instruc;
        Condition = condit;
        location = loc;
    }
    public override bool Validation()
    {
        if(!Condition.CheckType(IDType.Boolean)) Errors.Add($"A boolean expressions is expected at line: {Condition.Location.Line}, column: {Condition.Location.Column}");
        if(!Condition.Validation()) Errors.AddRange(Condition.Errors);
        if(!Instructions.Validation()) Errors.AddRange(Instructions.Errors);
        return Errors.Count == 0;
    }
    public override void Implement()
    {
        try{
            while((bool)Condition.Implement()) Instructions.Implement();
        }
        catch(InvalidCastException){
            Errors.Add($"The while condition at line: {Condition.Location.Line}, column: {Condition.Location.Column} is not a boolean expression");
        }
    }
}

public class For : Statement
{
    ExpressionDSL Collection;
    Statement Instructions;
    Scope Scope;
    Token ID;
    public For(ExpressionDSL collection, Statement instructions, Scope scope, Token token){
        Collection = collection;
        Instructions = instructions; 
        Scope = scope;
        ID = token;
    }

    public override CodeLocation Location => ID.Location;

    public override void Implement(){
        IEnumerator<object> collection = null;
        try{
            collection = ((IEnumerable<object>)Collection.Implement()).GetEnumerator();
        }
        catch(InvalidCastException){
            Errors.Add($"A collection was expected at line: {Collection.Location.Line}, column: {Collection.Location.Column}");
        }
        if(Scope.CheckDefinition(ID.Value)) Errors.Add($"Id already at us at line: {ID.Location.Line}, column: {ID.Location.Column}");

        while(collection.MoveNext()){
            Scope.Define(ID.Value, new UnaryObj(collection.Current, new CodeLocation(-1, -1)));
            Instructions.Implement();
        }
    }

    public override bool Validation()
    {
        if(!Instructions.Validation()) Errors.AddRange(Instructions.Errors);
        if(!Collection.Validation()) Errors.AddRange(Collection.Errors);
        //TODO: tengo que revisar esto, en el libro de referencia dice algo de que el id deberia ser de tipo lista pero esa no la tengo y no se muy bien cual seria
        if(Collection.CheckType(IDType.Boolean)) Errors.Add($"A boolean expressions is expected at line: {Collection.Location.Line}, column: {Collection.Location.Column}");

        return Errors.Count == 0;
    }
}