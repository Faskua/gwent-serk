using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
    private GameObject Cardentry;
    public GameObject cartagutts;
    public List<GameObject> CardsinFrange;
    public int Suma = 0;
    public Text puntuationText;
    public string Faction;
    public int franja;
    public GameObject CementerioGutts;
    public GameObject CementerioGriffith;
    public GameObject PlayerHand;
    public GameObject EnemyHand;
    public GameObject CuerpoaCuerpo;

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
            if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
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
    }

    public void Gutts()
    {
        foreach(GameObject Carta in CardsinFrange)
        {
            if(Carta.GetComponent<ClaseCarta>().Name == "Casca")
            {
                GameObject Gutts = Instantiate(cartagutts, new Vector2(0,0), Quaternion.identity);
                Gutts.transform.SetParent(CuerpoaCuerpo.transform, false);
                Gutts.transform.position = CuerpoaCuerpo.transform.position;
                break;
            }
        }
    }

    public void SkelletonKnight()
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            int mayor = CardsinFrange[0].GetComponent<ClaseCarta>().Power;
            for(int i = 0; i < CardsinFrange.Count; i++)
            {
                mayor = Mathf.Max(mayor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
            }
            foreach(GameObject card in CardsinFrange)
            {
                if(card.GetComponent<ClaseCarta>().Power == mayor)
                {
                    card.transform.position = CementerioGriffith.transform.position;
                    card.transform.SetParent(CementerioGriffith.transform, true);
                    CardsinFrange.Remove(card);
                    break;
                }
            }
        }
    }

    public void Irvine()
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            int menor = CardsinFrange[0].GetComponent<ClaseCarta>().Power;
            for(int i = 0; i < CardsinFrange.Count; i++)
            {
                menor = Mathf.Min(menor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
            }
            foreach(GameObject card in CardsinFrange)
            {
                if(card.GetComponent<ClaseCarta>().Power == menor)
                {
                    card.transform.position = CementerioGutts.transform.position;
                    card.transform.SetParent(CementerioGutts.transform, true);
                    CardsinFrange.Remove(card);
                    break;
                }
            }
        }
    }

    public int Danan()
    {
        int promedio = 0;
        foreach(GameObject carta in CardsinFrange)
        {
            promedio += carta.GetComponent<ClaseCarta>().Power;
        }
        return promedio;
    }
    public void AplicarDanan(int poder)
    {
        foreach(GameObject carta in CardsinFrange)
        {
            carta.GetComponent<ClaseCarta>().Power = poder;
        }
    }

    public void Flora()
    {
        foreach(GameObject Carta in CardsinFrange)
        {
            if(Carta.GetComponent<ClaseCarta>().Name == "Shierke" && Carta.GetComponent<ClaseCarta>().ShierkeAfectada == false)
            {
                Carta.GetComponent<ClaseCarta>().Power += 2;
                Carta.GetComponent<ClaseCarta>().ShierkeAfectada = true;
                break;
            }
        }
    }

    public void Zodd(int Franja)
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            if(CardsinFrange.Count < 4)
            {
                if(CardsinFrange.Count == Franja)
                {
                foreach(GameObject carta in CardsinFrange)
                {
                    carta.transform.position = CementerioGutts.transform.position;
                    carta.transform.SetParent(CementerioGutts.transform, true);
                }
                CardsinFrange.Clear();
                }
            }
        }
    }

    public void Eclipse()
    {
        foreach(GameObject carta in CardsinFrange)
        {
            carta.GetComponent<ClaseCarta>().Power = 1;
        }
    }

    public void Furia()
    {
        foreach(GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Affected == false)
            {
                card.GetComponent<ClaseCarta>().Affected = true;
                card.GetComponent<ClaseCarta>().Power += 1;
            }
        }
    }

    public void Amanecer()
    {
        foreach(GameObject card in CardsinFrange)
        {
            card.GetComponent<ClaseCarta>().Affected = false;
            card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower;
        }
    }

    public void Puck()
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
        int mayor = CardsinFrange[0].GetComponent<ClaseCarta>().Power;
        for(int i = 0; i < CardsinFrange.Count; i++)
        {
            mayor = Mathf.Max(mayor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
        }
        foreach(GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Power == mayor && card.GetComponent<ClaseCarta>().Faction == "Sacrificios")
            {
                card.transform.SetParent(PlayerHand.transform, false);
                card.transform.position = PlayerHand.transform.position;
                card.GetComponent<JugarCarta>().jugable = true;
                CardsinFrange.Remove(card);
            }
            if(card.GetComponent<ClaseCarta>().Power == mayor && card.GetComponent<ClaseCarta>().Faction == "Falconia")
            {
                card.transform.SetParent(EnemyHand.transform, false);
                card.transform.position = EnemyHand.transform.position;
                card.GetComponent<JugarCarta>().jugable = true;
                CardsinFrange.Remove(card);
            }
            break;
        }
        }
    }
    

    void Update() //lo tengo todo muy regado aqui
    {
        Ronda =  GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;
        PlayerHand = GameObject.Find("PlayerHand");
        EnemyHand = GameObject.Find("EnemyHand");


        sumaparcial = 0;
        for(int i = 0; i < CardsinFrange.Count; i++) // suma
        {
            sumaparcial += CardsinFrange[i].GetComponent<ClaseCarta>().Power;
        }
        Suma = sumaparcial;
        puntuationText.text = Suma.ToString();  //termina la suma
        
                //cuando termina la ronda reinicio todo y mando las cartas al cementerio correspondiente
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
