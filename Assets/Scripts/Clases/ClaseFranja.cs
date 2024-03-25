using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
    private GameObject Cardentry;
    public List<GameObject> CardsinFrange;
    public int Suma = 0;
    public Text puntuationText;

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista de la franja 
    {
        Cardentry = collision.gameObject;
        CardsinFrange.Add(Cardentry);
    }

    private void OnCollisionExit2D(Collision2D collision) // las saca de la lista 
    {
        CardsinFrange.Remove(Cardentry);
    }
    void Start()
    {
        
    }

    void Update()
    {
        foreach(GameObject Card in CardsinFrange)
        {
            if(Card.GetComponent<ClaseCarta>().Sumada == false)
            {
                Suma += Card.GetComponent<ClaseCarta>().Power;
                puntuationText.text = Suma.ToString();
                Card.GetComponent<ClaseCarta>().Sumada = true;
            }
        }
    }
}
