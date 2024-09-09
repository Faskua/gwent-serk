using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public void Building(){
        string code = GameObject.Find("Input").GetComponent<InputField>().text;
        Lexxer Lexer = new Lexxer();
        List<Token> tokens = Lexer.Tokenize(code);
        Parsel Parser = new Parsel(tokens);
        List<DSL> CardsnEffects = Parser.Parse();
        foreach (DSL Object in CardsnEffects){
            if( Object is CardDSL ){
                ICard card = (ICard)Object.Implement();
                CardSaver.AddCard(card);
            }
            if( Object is EffectDSL ){
                SavedEffect effect = (SavedEffect)Object.Implement();
                EffectSaver.AddEffect(effect);
            }
        }
    }
}
