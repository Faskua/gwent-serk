using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTurn : MonoBehaviour
{
    public bool Turno = true;
    public GameObject Bloqueo1;
    public GameObject Bloqueo2;
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparator1 = 0;
    private int comparator2 = 0;
    private RectTransform bloqueo1;
    private RectTransform bloqueo2;


    void Start()
    {
        bloqueo1 = Bloqueo1.GetComponent<RectTransform>();
        bloqueo2 = Bloqueo2.GetComponent<RectTransform>();
    }


    void Update()
    {
        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas;
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;

       if(Turno) //cambio de turno 
       {
        bloqueo2.sizeDelta = new Vector2(0, 0);
        bloqueo1.sizeDelta = new Vector2(550, 55);
        if(comparator1 != Mano1)
        {
            comparator1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false) //cambio de turno
       {
        bloqueo1.sizeDelta = new Vector2(0, 0);
        bloqueo2.sizeDelta = new Vector2(550, 55);
        if(comparator2 != Mano2)
        {
            comparator2 = Mano2;
            Turno = true;
        }
       }
    }
}
