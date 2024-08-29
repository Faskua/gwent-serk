#region ForUsing
using System.Dynamic;
using System.Runtime.InteropServices;

public abstract class DSL
{
    // Tipo general que contiene cartas y efectos
    public List<string> Errors = [];
    public abstract bool Validation(); //para analizar la semantica
    public abstract object? Implement();
    public abstract CodeLocation Location{ get; protected set;}
}

public abstract class Statement
{
    public abstract void Implement();
    public abstract bool Validation();
    public abstract CodeLocation Location{ get;}
    public List<string> Errors = []; 
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

// public class EffectDSL : DSL
// {
//     Expression Name { get;}
//     string? name;
//     Dictionary<Token, Token>? Params { get;}
//     InsBLock Action { get;}
//     public EffectDSL( Expression name, InsBLock action, Dictionary<Token, Token>? param){
//         Name = name;
//         Action = action;
//         Params = param;
//     }

//     public override bool Validation(){
//         Name.Validation();
//         Name.CheckType(IDType.String);
//         Action.Validation();
//         this.name = (string)Name.Implement();
//         if(Params != null){
//             //scope.DefineParam(this.name, Params); //ya confirme que es un string
//         }
//         this.Errors.AddRange(Name.Errors);
//         this.Errors.AddRange(Action.Errors);
//         return this.Errors.Count == 0;
//     }
//     public void ToEffectSaver(){
//         List<string> param = [];
//         if(Params != null){
//             foreach(var token in Params.Keys){
//                 param.Add(token.Value);
//             }
//         }
//         string context = Action.Context.Value;
//         string targets = Action.Targets.Value;
//         SavedEffect saved = new SavedEffect(this.name, Action, targets, context, param); 
//         EffectSaver.AddEffect(saved); //se guarda en la clase estatica 
//     }
// }

// #endregion

// #region Card

// public class CardDSL : DSL
// {
//     public Expression Type { get;}
//     public Expression Name { get;}
//     public Expression Power { get;}
//     public List<Expression> Range { get;}
//     public List<IEffect> Effects { get;}
//     public CardDSL(Expression type, Expression name, Expression power, List<Expression> range, List<IEffect> effects){
//         Type = type;
//         Name = name;
//         Power = power;
//         Range= range;
//         Effects = effects;
//     }

//     public override bool Validation(){
//         if(!Type.Validation())  this.Errors.AddRange(Type.Errors);
//         Type.CheckType( IDType.String);
//         if(!Name.Validation()) this.Errors.AddRange(Name.Errors);
//         Name.CheckType(IDType.String);
//         if(!Power.Validation()) this.Errors.AddRange(Power.Errors);
//         Power.CheckType(IDType.Number);
//         foreach (var range in Range){
//             if(!range.Validation()) this.Errors.AddRange(range.Errors);
//             range.CheckType(IDType.String);
//         }
//         return this.Errors.Count == 0;
//     }
// }

// #endregion

