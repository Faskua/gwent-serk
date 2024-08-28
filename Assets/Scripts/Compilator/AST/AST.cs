#region ForUsing
using System.Runtime.InteropServices;

public abstract class DSL
{
    // Tipo general que contiene cartas y efectos
    public abstract void Validation(IScope scope, out List<string> errors); //para analizar la semantica
}

public abstract class Instruction : DSL
{
    public abstract object? Implement();
}

class BlockToDec : DSL
{
    List<CardDSL> Cards { get; set;}
    List<EffectDSL> Effects { get; set;}
    public BlockToDec(List<CardDSL> cards, List<EffectDSL> effects){
        Cards = cards;
        Effects = effects;
    }
    public override void Validation(IScope scope, out List<string> errors){
        errors = [];
        foreach (var Effect in Effects){
            Effect.Validation(scope.CreateChild(), out errors);
        }
        foreach (var Card in Cards){
            Card.Validation(scope.CreateChild(), out errors);
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
    public void ImplementAll(){
        foreach (var Instruction in Instructions){
            Instruction.Implement();
        }
    }
    public override void Validation(IScope scope, out List<string> errors){
        errors = [];
        //Primero revisar si esta def target y context
        if(!scope.CheckDefinition(Targets.Value)) scope.Define(Targets.Value, IDType.Deck);
        if(!scope.CheckDefinition(Context.Value)) scope.Define(Context.Value, IDType.Context);

        foreach(var instruction in Instructions){
            instruction.Validation(scope, out errors);
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
    public override object? Implement()
    {
        while((bool)Condition.Implement()) Instructions.ImplementAll();
        return null;
    }

    public override void Validation(IScope scope, out List<string> errors)
    {
        errors = [];
        IScope Child = scope.CreateChild(); //cre un hijo y hago Validation desde el 
        Condition.CheckType(IDType.Boolean);
        Condition.Validation(Child, out errors);
        Instructions.Validation(Child, out errors);
    }
}

public class For : Instruction
{
    public override object Implement()
    {
        throw new NotImplementedException();
    }

    public override void Validation(IScope scope, out List<string> errors)
    {
        throw new NotImplementedException();
    }
}

#endregion

#region  Effect

public class EffectDSL : DSL
{
    Expression Name { get;}
    string? name;
    Dictionary<Token, Token>? Params { get;}
    InsBLock Action { get;}
    public EffectDSL( Expression name, InsBLock action, Dictionary<Token, Token>? param){
        Name = name;
        Action = action;
        Params = param;
    }

    public override void Validation(IScope scope, out List<string> errors){
        errors = [];
        Name.Validation(scope, out errors);
        Name.CheckType(IDType.String);
        Action.Validation(scope.CreateChild(), out errors);
        this.name = (string)Name.Implement();
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

public class CardDSL : DSL
{
    public Expression Type { get;}
    public Expression Name { get;}
    public Expression Power { get;}
    public List<Expression> Range { get;}
    public List<IEffect> Effects { get;}
    public CardDSL(Expression type, Expression name, Expression power, List<Expression> range, List<IEffect> effects){
        Type = type;
        Name = name;
        Power = power;
        Range= range;
        Effects = effects;
    }

    public override void Validation(IScope scope, out List<string> errors){
        errors = [];
        Type.Validation(scope, out errors);
        Type.CheckType( IDType.String);
        Name.Validation(scope, out errors);
        Name.CheckType(IDType.String);
        Power.Validation(scope, out errors);
        Power.CheckType(IDType.Number);
        foreach (var range in Range){
            range.Validation(scope, out errors);
            range.CheckType(IDType.String);
        }

    }
}

#endregion

