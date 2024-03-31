using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendirse : MonoBehaviour
{
    public bool Turn;
    public int Ronda;
    public int CompRonda = 1;
    public ClaseMano PlayerHand;
    public ClaseMano EnemyHand;

    public void SeRinde()
    {
        if(Turn)
        {
            PlayerHand.rendido = true;
        }
        if(Turn == false)
        {
            EnemyHand.rendido = true;
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        PlayerHand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();
        Ronda = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Ronda;

        if(CompRonda != Ronda)
        {
            CompRonda = Ronda;
            PlayerHand.rendido = false;
            EnemyHand.rendido = false;
        }
    }
}
