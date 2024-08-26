using System.Buffers;

public interface IScope
{
    //Recibe el nombre del efecto y el diccionario de los params
    bool DefineParam(string Name, Dictionary<Token, Token> param);
    //Crea un contexto
    IScope CreateChild();
    //Devuelve el IdType de un id
    IDType GetIdType(string id);
    //Recibe un id y revisa si esta definido
    bool CheckDefinition(string id);
    void Define(string Name, IDType id);
}

public interface IimplementScope
{
    //Crea un contexto
    IimplementScope CreateChild();
    //Devuelve el IdType de un id
    object? Value(string id);
    //Recibe un id y revisa si esta definido
    bool CheckDefinition(string id);
    void Define(string Name, object Value);
}

class Scope : IScope
{
    //Contexto padre que puede ser null
    IScope? Parent;
    //variables en el scope
    Dictionary<string, IDType> Variables = [];
    public IScope CreateChild(){
        var scope = new Scope();
        scope.Parent = this;
        return scope;
    }

    public void Define(string variable, IDType id){ //añade una variable al diccionario o cambia su valor si ya esta definida
        if(!CheckDefinition(variable)){
            Variables.Add(variable, id);
        }
        else Variables[variable] = id;

    }
    public bool CheckDefinition(string id){
        return (Parent != null && Parent.CheckDefinition(id)) || Variables.ContainsKey(id);
    }

    public bool DefineParam(string Name, Dictionary<Token, Token> param)
    {
        throw new NotImplementedException();
    }

    public IDType GetIdType(string id){ //si no esta definido en el contexto lanza error
        if (!CheckDefinition(id)) throw new Exception("Id not defined");
        return Variables[id];
    }
}
class ImplementScope : IimplementScope
{
    Dictionary<string, object> Variables = [];
    IimplementScope? Parent { get;}

    public ImplementScope(ImplementScope? parent){
        Parent = parent;
    }
    public bool CheckDefinition(string id)
    {
        if(Variables.ContainsKey(id) || (Parent != null && Parent.CheckDefinition(id))) return true;
        return false;
    }

    public object? Value(string id){
        if(Variables.ContainsKey(id)) return Variables[id];
        if(Parent != null) return Parent.Value(id);
        return null;
    }

    public IimplementScope CreateChild() => new ImplementScope(this);

    public void Define(string Name, object Value)
    {
        if(!CheckDefinition(Name)){ //Mirar si esta definida antes de añadirla
            Variables.Add(Name, Value);
            return;
        }
        Variables[Name] = Value; // si ya lo esta se cambia
    }
}

