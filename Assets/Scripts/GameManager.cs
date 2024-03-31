using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Ronda = 1;
    public Text WinsGuttsText;
    public string PointsGutts;
    public Text WinsGriffithText;
    public string PointsGriffith;
    public Text GanadorText;


    public bool playerRendido;
    public bool enemyRendido;
    private bool PartidaTerminada = false;
    private int VictoriasGutts = 0;
    private int VictoriasGriffith = 0;
    private int Mano1;
    private int Mano2;
    private bool Eroba;
    private bool Eroba2;
    private bool Eroba3;
    private bool Proba;
    private bool Proba2;
    private bool Proba3;


    public void WhoWon()
    {               //primera ronda
        if(Ronda == 1 && Mano1 == 0 && Mano2 == 0 && Proba && Eroba) // ninguno tiene cartas
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 1 && playerRendido && enemyRendido && Proba && Eroba) //ambos se rindieron
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 1 && playerRendido && Mano2 == 0 && Proba && Eroba)  //gutts se rindio y griffith no tiene cartas
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 1 && Mano1 == 0 && enemyRendido && Proba && Eroba)  //gutts no tiene cartas y griffith se rindio
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }

                    //segunda ronda
        if(Ronda == 2 && Mano1 == 0 && Mano2 == 0 && Proba2 && Eroba2) //lo mismo
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 2 && playerRendido && enemyRendido && Proba2 && Eroba2)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 2 && playerRendido && Mano2 == 0 && Proba2 && Eroba2)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }
        if(Ronda == 2 && Mano1 == 0 && enemyRendido && Proba2 && Eroba2)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda += 1;
        }

                    //tercera ronda
        if(Ronda == 3 && Mano1 == 0 && Mano2 == 0 && Proba3 && Eroba3) // again
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && playerRendido && enemyRendido && Proba3 && Eroba3)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && playerRendido && Mano2 == 0 && Proba3 && Eroba3)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && Mano1 == 0 && enemyRendido && Proba3 && Eroba3)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
    }
  
    void Update()
    {
        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas;
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;

        playerRendido = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().rendido;
        enemyRendido = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().rendido;


        PointsGutts = GameObject.Find("ContGutts").GetComponent<Text>().text;
        PointsGriffith = GameObject.Find("ContGriffith").GetComponent<Text>().text;

        Eroba = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;
        Proba = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
        Eroba2 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo2;
        Proba2 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo2;
        Eroba3 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo3;
        Proba3 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo3;



                    //Decidiendo el ganador
        if(PartidaTerminada == false && VictoriasGutts == 2)
        {
            PartidaTerminada = true;
            GanadorText.text = "Gutts Ha Ganado!!";
        }

        if(PartidaTerminada == false && VictoriasGriffith == 2)
        {
            PartidaTerminada = true;
            GanadorText.text = "Griffith Ha Ganado!!";
        }
    }
}
