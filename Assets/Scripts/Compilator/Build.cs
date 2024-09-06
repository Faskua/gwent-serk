using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    string InputText = GameObject.Find("Input").GetComponent<InputField>.text;
    Lexxer lexer = new Lexxer();
    List<Token> tokens = lexer.Tokenize();
    Parsel parser = new Parsel(tokens);
    List<DSL> cardsnEffects = parser.Parse();
}
