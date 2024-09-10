using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetImage : MonoBehaviour
{
    Image Card;

    void Start(){
        Card = GameObject.FindWithTag("CardImage").GetComponent<Image>();
    }
    public void Image(){
        Card.sprite = gameObject.GetComponent<Image>().sprite;
    }
}
