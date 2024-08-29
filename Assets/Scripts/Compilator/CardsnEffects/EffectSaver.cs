
using System.Net.Mime;

public static class EffectSaver
{
    public static HashSet<SavedEffect> Effects = [];
    public static void AddEffect(SavedEffect effect){
        Effects.Add(effect);
    }
    public static SavedEffect Search(string name){
        SavedEffect? output = Effects.FirstOrDefault(e => e.Name == name);
        if (output == null) throw new Exception("Effect not found");
        return output;
    }
}

public class SavedEffect
{
    public string Name { get;}
    public SavedEffect? Parent { get;}
    public string TargetsNames { get;}
    public string Context { get;}
    public Dictionary<string,object?> Params { get;}
    //public EffectSelector Targets { get;}
    public SavedEffect? PostAction { get;}
    InsBLock Action { get;}
    public SavedEffect(string name, InsBLock action, string targetname, string context, List<string>  param){
        Name = name;
        TargetsNames = targetname;
        Context = context;
        Action = action;
        Params = new Dictionary<string, object?>();
        foreach (var paramname in param){
            Params.Add(paramname, null);
        }
    }
    public void ParamValues(Dictionary<string, object> input){
        foreach (var name in input.Keys){
            if(Params.ContainsKey(name)){
                Params[name] = input[name];
            }
        }
    }
    public void Implement(IimplementScope? scope, SavedEffect? parent = null){ //ambos pueden ser nulos, el parent es para los postaction
        if(scope == null) scope = new ImplementScope(null);
        //TODO: Antes de hacer lo de abajo hay que definir en el scope el context y  lo targets
        //scope.Define(Context, );
        //scope.Define(TargetsNames, );
        if ( Params != null){
            foreach (var name in Params.Keys){
                scope.Define(name, Params[name]);
            }
        }
        Action.ImplementAll();
        if(PostAction != null) PostAction.Implement(scope, this);
    }
}
class ActionSave
{
    public Dictionary<string,Dictionary<string,Expression>?> SavedActions = [];

    public void CheckParams(string Name, Dictionary<string, Expression>? Params, IScope scope){
        if(!SavedActions.ContainsKey(Name)) throw new Exception("Not Defined Effect");

        // if(Params == null){
        //     if(SavedActions.ContainsKey(Name)) throw new Exception("Uncorrect Params");
        //     return; //no puede estar el effecto sin params
        // }
        foreach (string ID in Params.Keys)
        {
            Expression expected = Params[ID];
            if(SavedActions[Name].ContainsKey(ID) && SavedActions[Name][ID] == expected){ //Si son iguales tanto en el Saved como en Params
                scope.Define(ID, expected); // se define en el scope y se pasa al siguiente
                continue;
            }
            throw new Exception($"Params or Name definition are wrong with the action {Name}");
        }
    }
}



