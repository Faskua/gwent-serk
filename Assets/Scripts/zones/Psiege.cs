using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psiege : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;

    private bool jugable = true;
    //private GameObject turnCounter;


    void Start()
    {
        Zone = GameObject.Find("PlayerSiege");
       // turnCounter = GameObject.Find("TurnCounter");
    }

    public void PlayCard()
    {
        string faccion = Card.GetComponent<ClaseCarta>().Faction;
        //int turno = turnCounter.GetComponent<Counter>().TurnCounter;

        if(jugable && faccion == "Sacrificios" /*&& turno%2 == 1*/)
        {
        Card.transform.SetParent(Zone.transform, false);
        Card.transform.position = Zone.transform.position;
        jugable = false;
        //turno = turno + 1;
        }
         else if(jugable && faccion == "Falconia" /* && turno%2 == 0*/)
        {
        Card.transform.SetParent(Zone.transform, false);
        Card.transform.position = Zone.transform.position;
        jugable = false;
        // turno = turno + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
