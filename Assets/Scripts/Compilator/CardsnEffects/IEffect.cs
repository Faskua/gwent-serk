using System;
using System.Collections.Generic;

public interface IEffect{
    ExpressionDSL Name { get;}
    Dictionary<string, ExpressionDSL> Params { get;}
    Statement Action{ get;}
    IEffect PostAction { get;}
    public void Implement();
}