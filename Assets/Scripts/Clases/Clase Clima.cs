using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseClima : MonoBehaviour
{
     private GameObject Cardentry;
     public List<GameObject> CardsinFrange;
     public string Faction;
     public GameObject CementerioGutts;
     public GameObject CementerioGriffith;
     private int ComprobadordeRonda = 1;
     private int Ronda = 1;

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista de la franja 
     {
        Cardentry = collision.gameObject; //designandoa la carta nueva en lalista como lo que sea que colisione
        CardsinFrange.Add(Cardentry); // meto la carta nueva en la lista 
     }


     void Update()
     {
            Ronda =  GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;

        if(ComprobadordeRonda != Ronda)
        {
            ComprobadordeRonda = Ronda;
            if(Faction == "Sacrificios")
            {
                foreach(GameObject carta in CardsinFrange)
                {
                    carta.transform.SetParent(CementerioGutts.transform, false);
                    carta.transform.position = CementerioGutts.transform.position;
                }
                CardsinFrange.Clear();
            }

             if(Faction == "Falconia")
            {
                foreach(GameObject carta in CardsinFrange)
                {
                    carta.transform.SetParent(CementerioGriffith.transform, false);
                    carta.transform.position = CementerioGriffith.transform.position;
                }
                CardsinFrange.Clear();
            }
        }
     }
}
