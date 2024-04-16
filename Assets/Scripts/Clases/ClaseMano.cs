using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaseMano : MonoBehaviour
{
     private GameObject Cardentry; //objeto que colisiona
     public List<GameObject> CardsinFrange;
     public int Cartas = 0;
     public int CartasDevueltas = 0;
     public bool rendido = false;//booleano para guardar si el jugador se rinde o no

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
