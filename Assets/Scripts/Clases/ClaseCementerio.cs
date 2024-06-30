using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseCementerio : MonoBehaviour
{
    private GameObject Cardentry; //objeto que colisiona
     public List<GameObject> DeadCards;
     public GameObject Mano;

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista del cemebterio 
     {
        Cardentry = collision.gameObject;
        DeadCards.Add(Cardentry);
     }

    private void OnCollisionExit2D(Collision2D collision) // las saca de la lista 
     {
        DeadCards.RemoveAt(0);
     }

     public void RegresarMuerto()
     {
        if(DeadCards.Count >= 1)
        {
            int position = Random.Range(0, DeadCards.Count);
            DeadCards[position].GetComponent<JugarCarta>().jugable = true;
            DeadCards[position].GetComponent<JugarCarta>().PlayCard();
        }
     }
}
