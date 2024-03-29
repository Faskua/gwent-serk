using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMano : MonoBehaviour
{
     private GameObject Cardentry;
     public List<GameObject> CardsinFrange;
     public int Cartas = 0;

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista de la franja 
     {
        Cardentry = collision.gameObject;
        CardsinFrange.Add(Cardentry);
        Cartas += 1;
     }

    private void OnCollisionExit2D(Collision2D collision) // las saca de la lista 
     {
        CardsinFrange.RemoveAt(0);
        Cartas -= 1;
     }
}
