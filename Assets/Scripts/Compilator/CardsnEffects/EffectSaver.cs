
using System.Net.Mime;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class EffectSaver
{
    public static HashSet<SavedEffect> Effects = new HashSet<SavedEffect>();
    public static void AddEffect(SavedEffect effect){
        Effects.Add(effect);
    }
    public static SavedEffect Search(string name){
        SavedEffect? output = Effects.FirstOrDefault(e => e.Name == name);
        if (output == null) ErrorThrower.AddError("Effect not found");
        return output;
    }
}

public static class CardSaver
{
    public static List<(ICard, string, Sprite)> Cards = new List<(ICard, string, Sprite)>();
    public static void AddCard(ICard card, string descripción, Sprite image){
        Cards.Add((card, descripción, image));
    }
}

public class SavedEffect
{
    public string Name { get;}
    public SavedEffect? Parent { get;}
    public string TargetsNames { get;}
    public string Context { get;}
    public Dictionary<string,ExpressionDSL?> Params { get;}
    //public EffectSelector Targets { get;}
    public SavedEffect? PostAction { get;}
    Action Action { get;}
    public SavedEffect(string name, Action action, string targetname, string context, List<string>  param){
        Name = name;
        TargetsNames = targetname;
        Context = context;
        Action = action;
        Params = new Dictionary<string, ExpressionDSL?>();
        foreach (var paramname in param){
            Params.Add(paramname, null);
        }
    }
    public void ParamValues(Dictionary<string, ExpressionDSL?> input){
        foreach (var name in input.Keys){
            if(Params.ContainsKey(name)){
                Params[name] = input[name];
            }
        }
    }
    public void Implement(Scope scope, SavedEffect? parent = null){ //ambos pueden ser nulos, el parent es para los postaction
        if(scope == null) scope = new Scope(null);
        //TODO: Antes de hacer lo de abajo hay que definir en el scope el context y  lo targets
        //scope.Define(Context, );
        //scope.Define(TargetsNames, );
        if ( Params != null){
            foreach (var name in Params.Keys){
                scope.Define(name, Params[name]);
            }
        }
        Action.Block.Implement();
        if(PostAction != null) PostAction.Implement(scope, this);
    }
}
class ActionSave
{
    public Dictionary<string,Dictionary<string,ExpressionDSL>?> SavedActions = new Dictionary<string, Dictionary<string, ExpressionDSL>?>();

    public void CheckParams(string Name, Dictionary<string, ExpressionDSL>? Params, Scope scope){
        if(!SavedActions.ContainsKey(Name)) ErrorThrower.AddError("Not Defined Effect");

        // if(Params == null){
        //     if(SavedActions.ContainsKey(Name)) throw new Exception("Uncorrect Params");
        //     return; //no puede estar el effecto sin params
        // }
        foreach (string ID in Params.Keys)
        {
            ExpressionDSL expected = Params[ID];
            if(SavedActions[Name].ContainsKey(ID) && SavedActions[Name][ID] == expected){ //Si son iguales tanto en el Saved como en Params
                scope.Define(ID, expected); // se define en el scope y se pasa al siguiente
                continue;
            }
            ErrorThrower.AddError($"Params or Name definition are wrong with the action {Name}");
        }
    }
}



