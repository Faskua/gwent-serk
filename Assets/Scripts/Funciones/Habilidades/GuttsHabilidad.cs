using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuttsHabilidad : MonoBehaviour
{
    public ClaseFranja CC;
    public bool Utilizada = false;
    public bool turn;

    public void Habilidad()
    {
        if(Utilizada == false && turn)
        {
            CC.Gutts();
            Utilizada = true;
        }
    }

    void Update()
    {
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>();
    }
}
