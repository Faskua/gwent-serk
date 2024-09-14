using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public string description = "";
    public InputField code;
    public InputField descrp;
    public Text Errors;
    private Image image;

    public void Building(){
        string Code = code.text;
        description = descrp.text;
        Lexxer Lexer = new Lexxer();
        List<Token> tokens = Lexer.Tokenize(Code);
        Parsel Parser = new Parsel(tokens);
        List<DSL> CardsnEffects = Parser.Parse();
        foreach (DSL Object in CardsnEffects){
            if( Object is CardDSL ){
                ICard card = (ICard)Object.Implement();
                CardSaver.AddCard(card, description, image.sprite);
            }
            if( Object is EffectDSL ){
                SavedEffect effect = (SavedEffect)Object.Implement();
                EffectSaver.AddEffect(effect);
            }
        }
        Errors.text = ErrorThrower.ThrowNReset();
    }
    void Start(){
        description = "Esta carta es aburrida y no tiene descripción";
        code = GameObject.FindWithTag("InputCode").GetComponent<InputField>();
        descrp = GameObject.FindWithTag("InputDes").GetComponent<InputField>();
        image = GameObject.FindWithTag("CardImage").GetComponent<Image>();
        Errors = GameObject.FindWithTag("CompilingErrors").GetComponent<Text>();
    }
}
