using System.Dynamic;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;

#region ForUsing
public abstract class DSL
{
    // Tipo general que contiene cartas y efectos
    public List<string> Errors = new List<string>();
    public abstract bool Validation(); //para analizar la semantica
    public abstract object? Implement();
    public abstract CodeLocation Location{ get; protected set;}
}

public abstract class Statement
{
    public abstract void Implement();
    public abstract bool Validation();
    public abstract CodeLocation Location{ get;}
    public List<string> Errors = new List<string>(); 
}

// public class BlockToDec : DSL
// {
//     List<CardDSL> Cards { get; set;}
//     List<EffectDSL> Effects { get; set;}
//     public BlockToDec(List<CardDSL> cards, List<EffectDSL> effects){
//         Cards = cards;
//         Effects = effects;
//     }
//     public override bool Validation(){
//         foreach (var Effect in Effects){
//             if(!Effect.Validation())
//                 this.Errors.AddRange(Effect.Errors);
//         }
//         foreach (var Card in Cards){
//             if(!Card.Validation())
//                 this.Errors.AddRange(Card.Errors);
//         }
//         return Errors.Count == 0;
//     }
//     public List<ICard> Evaluate(){
//         foreach (var effect in Effects){ //gurado todos los efectos en la clase estatica
//             effect.ToEffectSaver();
//         }
//         //TODO: tengo que hacer el metodo evalate de Cards
//         throw new NotImplementedException();
//     }
// }
// public class InsBLock : DSL{
//     public Token Context { get;}
//     public Token Targets { get;}
//     public List<Statement> Instructions { get;}
//     public InsBLock(Token context, Token targets, List<Instruction> instructions){
//         Context = context;
//         Targets = targets;
//         Instructions = instructions;
//     }
//     public void ImplementAll(){
//         foreach (var Instruction in Instructions){
//             Instruction.Implement();
//         }
//     }
//     public override bool Validation(){
//         //Primero revisar si esta def target y context
//         //if(!scope.CheckDefinition(Targets.Value)) scope.Define(Targets.Value, IDType.Deck);
//         //if(!scope.CheckDefinition(Context.Value)) scope.Define(Context.Value, IDType.Context);

//         //TODO tengo que revisar esto
//         foreach(var instruction in Instructions){
//             instruction.Validation();
//         }
//         return Errors.Count == 0;
//     }
// }

 #endregion

// #region  Effect

public class EffectDSL : DSL
{
    ExpressionDSL Name { get;}
    string? name;
    Dictionary<string, ExpressionDSL>? Params { get;}
    Action Action { get;}
    public override CodeLocation Location { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public EffectDSL( ExpressionDSL name, Action action, Dictionary<string, ExpressionDSL>? param){
        Name = name;
        Action = action;
        Params = param;
    }

    public override bool Validation(){
        Name.Validation();
        Name.CheckType(IDType.String);
        Action.Block.Validation();
        this.name = (string)Name.Implement();
        if(Params != null){
            //scope.DefineParam(this.name, Params); //ya confirme que es un string
        }
        this.Errors.AddRange(Name.Errors);
        this.Errors.AddRange(Action.Block.Errors);
        return this.Errors.Count == 0;
    }
    public void ToEffectSaver(){
        List<string> param = new List<string>();
        if(Params != null){
            foreach(var name in Params.Keys){
                param.Add(name);
            }
        }
        // string context = Action.Context.Value;
        // string targets = Action.Targets.Value;
        // SavedEffect saved = new SavedEffect(this.name, Action, targets, context, param); 
        // EffectSaver.AddEffect(saved); //se guarda en la clase estatica 
    }

    public override object? Implement()
    {
        throw new NotImplementedException();
    }
}

// #endregion

#region Card

public class CardDSL : DSL
{
    public ExpressionDSL Type { get;}
    public ExpressionDSL Name { get;}
    public ExpressionDSL Power { get;}
    public ExpressionDSL Faction { get; }
    public List<ExpressionDSL> Ranges { get;}
    public List<SavedEffect> Effects { get;}
    public override CodeLocation Location { get => throw new NotImplementedException(); protected set => throw new NotImplementedException(); }

    public CardDSL(ExpressionDSL type, ExpressionDSL name, ExpressionDSL power, ExpressionDSL faction, List<ExpressionDSL> range, List<SavedEffect> effects){
        Type = type;
        Name = name;
        Power = power;
        Faction = faction;
        Ranges = range;
        Effects = effects;
    }

    public override bool Validation(){
        if(!Type.Validation())  this.Errors.AddRange(Type.Errors);
        Type.CheckType( IDType.String);
        if(!Name.Validation()) this.Errors.AddRange(Name.Errors);
        Name.CheckType(IDType.String);
        if(!Power.Validation()) this.Errors.AddRange(Power.Errors);
        Power.CheckType(IDType.Number);
        if(!Faction.Validation()) this.Errors.AddRange(Faction.Errors);
        Faction.CheckType(IDType.String);
        foreach (var range in Ranges){
            if(!range.Validation()) this.Errors.AddRange(range.Errors);
            range.CheckType(IDType.String);
        }
        return this.Errors.Count == 0;
    }

    public override object Implement(){
        if(!Validation()){ 
            ErrorThrower.RangeError(this.Errors);
            return null;
        }
        else{
            string name = (string)Name.Implement();
            double power = ((Int)Power.Implement()).Value;
            string faction = (string)Faction.Implement();
            string type = (string)Type.Implement();
            List<string> ranges = new List<string>();
            foreach (var range in Ranges){
                string Range = (string)range.Implement();
                if( !(Range == "Melee" || Range == "Distance" || Range == "Siege") ) ErrorThrower.AddError($"Unvalid range value at line: {range.Location.Line}, column: {range.Location.Column}");
                else ranges.Add(Range);
            }
            if(faction == "Sacrificios" || faction == "Falconia"){
                switch(type){
                    case "Leader":
                        if(Name != null && Faction != null && Effects != null){ 
                        ICard card = new Leader(name, faction, 0, type, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                        case "Golden":
                        if(Name != null && Power != null && Faction != null && Ranges != null){ 
                        ICard card = new Golden(name, faction, power, type, ranges, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                    case "Silver":
                        if(Name != null && Power != null && Faction != null && Ranges != null){ 
                        ICard card = new Silver(name, faction, power, type, ranges, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                    case "Dummy":
                        if(Name != null && Power != null && Faction != null && Ranges != null && Effects != null){ 
                        ICard card = new Dummy(name, faction, power, type, ranges, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                    case "Buff":
                        if(Name != null && Faction != null && Ranges != null && Effects != null){ 
                        ICard card = new Buff(name, faction, power, type, ranges, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                    default:
                        if(Name != null && Faction != null && Ranges != null && Effects != null){ 
                        ICard card = new Weather(name, faction, power, type, ranges, Effects);
                        return card;
                        }
                        else {
                            ErrorThrower.AddError($"There are Parameters to fill with card at line: {Type.Location.Line}, column: {Type.Location.Column}");
                            return null;
                        }
                }
            }
            else{
                ErrorThrower.AddError($"Unvalid faction value at line: {Faction.Location.Line}, column: {Faction.Location.Column}");
                return null;
            }
        }
    }
}

#endregion

