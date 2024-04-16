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
    private bool robaJ;
    private bool robaE;
   // private bool griffElige;
    //private bool guttsElige;

    public void SeRinde()
    {
        if(Turn && robaJ)// && guttsElige)
        {
            PlayerHand.rendido = true;
        }
        if(Turn == false && robaE )//&& griffElige)
        {
            EnemyHand.rendido = true;
        }
    }

    void Update()
    {   
        //guttsElige = GameObject.Find("CartasGutts").GetComponent<chosencardsgutts>().chosecards;
        //griffElige = GameObject.Find("CartasGriffith").GetComponent<chosencardsgrif>().chosecards;

        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        PlayerHand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();
        Ronda = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Ronda;
        robaJ = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
        robaE = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;
        if(CompRonda != Ronda)
        {
            CompRonda = Ronda;
            PlayerHand.rendido = false;
            EnemyHand.rendido = false;
        }
    }
}
