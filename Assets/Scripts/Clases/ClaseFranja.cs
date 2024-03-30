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
    public string Faction;
    public GameObject CementerioGutts;
    public GameObject CementerioGriffith;
    private int ComprobadordeRonda = 1;
    private int Ronda = 1;
    private bool efectogrunbeld = true;
    private int sumaparcial = 0;

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista de la franja 
    {
        Cardentry = collision.gameObject;
        CardsinFrange.Add(Cardentry);
    }

    public void Grunbeld()
    {
      foreach(GameObject Card in CardsinFrange)
      {
         Card.GetComponent<ClaseCarta>().Power +=1;
      }
    }

    public void Griffith()
    {
        if(Faction == "Sacrificios")
        {
            int menor = CardsinFrange[0].GetComponent<ClaseCarta>().Power;
            for(int i = 0; i < CardsinFrange.Count; i++)
            {
                menor = Mathf.Min(menor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
            }
            foreach(GameObject cartas in CardsinFrange)
            {
                if(cartas.GetComponent<ClaseCarta>().Power == menor)
                {
                    cartas.transform.SetParent(CementerioGutts.transform, true);
                    cartas.transform.position = CementerioGutts.transform.position;
                    CardsinFrange.Remove(cartas);
                    break;
                }
            }
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        sumaparcial = 0;
        for(int i = 0; i < CardsinFrange.Count; i++) // suma
        {
            sumaparcial += CardsinFrange[i].GetComponent<ClaseCarta>().Power;
        }
        Suma = sumaparcial;
        puntuationText.text = Suma.ToString();

        Ronda =  GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;

        if(ComprobadordeRonda != Ronda)
        {
            ComprobadordeRonda = Ronda;
            if(Faction == "Sacrificios")
            {
                foreach(GameObject carta in CardsinFrange)
                {
                    carta.transform.SetParent(CementerioGutts.transform, true);
                    carta.transform.position = CementerioGutts.transform.position;
                }
                CardsinFrange.Clear();
                 Suma = 0;
                puntuationText.text = Suma.ToString();
            }

             if(Faction == "Falconia")
            {
                foreach(GameObject carta in CardsinFrange)
                {
                    carta.transform.SetParent(CementerioGriffith.transform, true);
                    carta.transform.position = CementerioGriffith.transform.position;
                }
                CardsinFrange.Clear();
                Suma = 0;
                puntuationText.text = Suma.ToString();
            }
        }
 
                 //efecto de grunbeld
        foreach(GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Grunbeld, El Dragón de Fuego" && efectogrunbeld)
            {
                efectogrunbeld = false;
               Grunbeld();
            }
        }
    }
}
