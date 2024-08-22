public interface IScope
{
    //Recibe el nombre del efecto y el diccionario de los params
    bool DefineParam(string Name, Dictionary<Token, Token> param);
    //Crea un contexto
    IScope CreateContext();
    //Devuelve el IdType de un id
    IDType GetIdType(string id);
    //Recibe un id y revisa si esta definido
    bool IsDefined(string id);
    void Define(string Name, IDType id);
}

class Scope : IScope
{
    //Contexto padre que puede ser null
    IScope? Parent;
    //variables en el scope
    Dictionary<string, IDType> Variables = [];
    public IScope CreateContext(){
        var scope = new Scope();
        scope.Parent = this;
        return scope;
    }

    public void Define(string variable, IDType id){ //añade una variable al diccionario o cambia su valor si ya esta definida
        if(!IsDefined(variable)){
            Variables.Add(variable, id);
        }
        else Variables[variable] = id;

    }
    public bool IsDefined(string id){
        return (Parent != null && Parent.IsDefined(id)) || Variables.ContainsKey(id);
    }

    public bool DefineParam(string Name, Dictionary<Token, Token> param)
    {
        throw new NotImplementedException();
    }

    public IDType GetIdType(string id){ //si no esta definido en el contexto lanza error
        if (!IsDefined(id)) throw new Exception("Id not defined");
        return Variables[id];
    }
}

class ActionSave
{
    public Dictionary<string,Dictionary<string,IDType>?> SavedActions = [];

    public void CheckParams(string Name, Dictionary<Token, Expression>? Params, IScope scope){
        if(!SavedActions.ContainsKey(Name)) throw new Exception("Not Defined Effect");

        if(Params == null){
            if(SavedActions.ContainsKey(Name)) throw new Exception("Uncorrect Params");
            return; //Si el diccionario es null y su nombre no esta entonces no hay nada que hacer
        }
        foreach (Token ID in Params.Keys)
        {
            IDType expected = Params[ID].Type(scope);
            if(SavedActions[Name].ContainsKey(ID.Value) && SavedActions[Name][ID.Value] == expected){ //Si son iguales tanto en el Saved como en Params
                scope.Define(ID.Value, expected); // se define en el scope y se pasa al siguiente
                continue;
            }
            throw new Exception("Something went wrong");
        }
    }
}