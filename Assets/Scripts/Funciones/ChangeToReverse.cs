using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeToReverse : MonoBehaviour
{
    public Sprite Reverse;
    public Sprite Foto;
    private bool Turn;
    private bool GriffRendido;
    private bool GuttsRendido;
    void Awake()
    {
        Foto = gameObject.GetComponent<Image>().sprite;
    }

    void Update()
    {
        GriffRendido = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().rendido;
        GuttsRendido = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().rendido;
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;

        if(GuttsRendido && GriffRendido)
        {
            if(gameObject.GetComponent<JugarCarta>().jugable) gameObject.GetComponent<Image>().sprite = Reverse;
        }
        else if(Turn)
        {
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<JugarCarta>().jugable)
            {
                gameObject.GetComponent<Image>().sprite = Reverse;
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<JugarCarta>().jugable)
            {
                gameObject.GetComponent<Image>().sprite = Foto;
            }
        }
        else
        {
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Falconia" && gameObject.GetComponent<JugarCarta>().jugable)
            {
                gameObject.GetComponent<Image>().sprite = Foto;
            }
            if(gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios" && gameObject.GetComponent<JugarCarta>().jugable)
            {
                gameObject.GetComponent<Image>().sprite = Reverse;
            }
        }
    }
}
