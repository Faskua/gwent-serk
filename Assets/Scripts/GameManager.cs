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

    private int VictoriasGutts = 0;
    private int VictoriasGriffith = 0;
    private int Mano1;
    private int Mano2;
    private bool Eroba;
    private bool Proba;


    public void WhoWin()
    {
        if(Ronda == 1 && Mano1 == 0 && Mano2 == 0 && Proba && Eroba)
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
    }
  
    void Update()
    {
        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas;
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;

        PointsGutts = GameObject.Find("ContGutts").GetComponent<Text>().text;
        PointsGriffith = GameObject.Find("ContGriffith").GetComponent<Text>().text;

        Eroba = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;
        Proba = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
    }
}
