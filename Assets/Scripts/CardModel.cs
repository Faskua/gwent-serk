using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardModel : MonoBehaviour
{
    public string Name;
    public double Power;
    public double OriginalPower;
    public string Description;
    public string Type;
    public List<string> Ranges;
    public string Faction;
    
    public List<SavedEffect> Effects;

    public CardModel(ICard card, Sprite picture, string description){
        Name = card.Name;
        Power = card.Power;
        OriginalPower = Power;
        Description = description;
        Type = card.Type;
        Ranges = card.Ranges;
        Faction = card.Faction;
        gameObject.GetComponent<Image>().sprite = picture;
        Effects = card.Effects;
    }


}
