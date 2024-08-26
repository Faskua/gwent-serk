#region ForUsing
using System.Runtime.InteropServices;

public abstract class DSL
{
    // Tipo general que contiene cartas y efectos
    public abstract void Validation(IScope scope); //para analizar la semantica
}

public abstract class Instruction : DSL
{
    public abstract object Implement(IimplementScope scope);
}

class BlockToDec : DSL
{
    List<Card> Cards { get; set;}
    List<Effect> Effects { get; set;}
    public BlockToDec(List<Card> cards, List<Effect> effects){
        Cards = cards;
        Effects = effects;
    }
    public override void Validation(IScope scope){
        foreach (var Effect in Effects){
            Effect.Validation(scope.CreateChild());
        }
        foreach (var Card in Cards){
            Card.Validation(scope.CreateChild());
        }
    }
    public List<ICard> Evaluate(){
        foreach (var effect in Effects){ //gurado todos los efectos en la clase estatica
            effect.ToEffectSaver();
        }
        //TODO: tengo que hacer el metodo evalate de Cards
        throw new NotImplementedException();
    }
}
public class InsBLock : DSL{
    public Token Context { get;}
    public Token Targets { get;}
    public List<Instruction> Instructions { get;}
    public InsBLock(Token context, Token targets, List<Instruction> instructions){
        Context = context;
        Targets = targets;
        Instructions = instructions;
    }
    public void ImplementAll(IimplementScope scope){
        foreach (var Instruction in Instructions){
            Instruction.Implement(scope);
        }
    }
    public override void Validation(IScope scope){
        //Primero revisar si esta def target y context
        if(!scope.CheckDefinition(Targets.Value)) scope.Define(Targets.Value, IDType.Deck);
        if(!scope.CheckDefinition(Context.Value)) scope.Define(Context.Value, IDType.Context);

        foreach(var instruction in Instructions){
            instruction.Validation(scope);
        }
    }
}

#endregion

#region Loops
public class While : Instruction
{
    InsBLock Instructions { get;}
    Expression Condition { get;}
    public While(InsBLock instruc, Expression condit){
        Instructions = instruc;
        Condition = condit;
    }
    public override object Implement(IimplementScope scope)
    {
        while((bool)Condition.Implement(scope)) Instructions.ImplementAll(scope);
        return null;
    }

    public override void Validation(IScope scope)
    {
        IScope Child = scope.CreateChild(); //cre un hijo y hago Validation desde el 
        Condition.CheckType(Child, IDType.Boolean);
        Condition.Validation(Child);
        Instructions.Validation(Child);
    }
}

public class For : Instruction
{
    public override object Implement(IimplementScope scope)
    {
        throw new NotImplementedException();
    }

    public override void Validation(IScope scope)
    {
        throw new NotImplementedException();
    }
}

#endregion

#region  Effect

public class Effect : DSL
{
    Expression Name { get;}
    string? name;
    Dictionary<Token, Token>? Params { get;}
    InsBLock Action { get;}
    public Effect( Expression name, InsBLock action, Dictionary<Token, Token>? param){
        Name = name;
        Action = action;
        Params = param;
    }

    public override void Validation(IScope scope){
        Name.Validation(scope);
        Name.CheckType(scope, IDType.String);
        Action.Validation(scope.CreateChild());
        this.name = (string)Name.Evaluate();
        if(Params != null){
            scope.DefineParam(this.name, Params); //ya confirme que es un string
        }
    }
    public void ToEffectSaver(){
        List<string> param = [];
        if(Params != null){
            foreach(var token in Params.Keys){
                param.Add(token.Value);
            }
        }
        string context = Action.Context.Value;
        string targets = Action.Targets.Value;
        SavedEffect saved = new SavedEffect(this.name, Action, targets, context, param); 
        EffectSaver.AddEffect(saved); //se guarda en la clase estatica 
    }
}

#endregion

#region Card

public class Card : DSL
{
    public Expression Type { get;}
    public Expression Name { get;}
    public Expression Power { get;}
    public List<Expression> Range { get;}
    public List<IEffect> Effects { get;}
    public Card(Expression type, Expression name, Expression power, List<Expression> range, List<IEffect> effects){
        Type = type;
        Name = name;
        Power = power;
        Range= range;
        Effects = effects;
    }

    public override void Validation(IScope scope){
        Type.Validation(scope);
        Type.CheckType(scope, IDType.String);
        Name.Validation(scope);
        Name.CheckType(scope, IDType.String);
        Power.Validation(scope);
        Power.CheckType(scope, IDType.Number);
        foreach (var range in Range){
            range.Validation(scope);
            range.CheckType(scope, IDType.String);
        }

    }
}

#endregion

