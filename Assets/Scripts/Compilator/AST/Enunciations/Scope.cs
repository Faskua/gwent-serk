using System.Buffers;
using System.Collections.Generic;
using System;

public class Scope
{
    static Scope? global;
    Scope? Parent;
    //variables en el scope
    Dictionary<string, ExpressionDSL> Variables = new Dictionary<string, ExpressionDSL>();
    public Scope(Scope parent){
        Parent = parent;
    }
    public Scope CreateChild(){
        var scope = new Scope(this);
        return scope;
    }
    public static Scope Global{
        get{
            if(global == null){
                global = new Scope(null);
                global.Define("context", new GameContext());
            }
            return global;
        }
    }

    public void Define(string variable, ExpressionDSL id){ //añade una variable al diccionario o cambia su valor si ya esta definida
        if(!CheckDefinition(variable)){
            Variables.Add(variable, id);
        }
        else if(Variables.ContainsKey(variable)) Variables[variable] = id;
        else Parent.Define(variable, id);

    }
    public bool CheckDefinition(string id){
        return (Parent != null && Parent.CheckDefinition(id)) || Variables.ContainsKey(id);
    }

    public bool DefineParam(string Name, Dictionary<Token, Token> param)
    {
        throw new NotImplementedException();
    }

    public ExpressionDSL GetExp(string id){ //si no esta definido en el contexto lanza error
        if (!CheckDefinition(id)) {ErrorThrower.AddError("Id not defined"); return null;}
        if(Variables.ContainsKey(id)) return Variables[id];
        else return Parent.GetExp(id);
    }
}

