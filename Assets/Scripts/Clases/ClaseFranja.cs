using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaseFranja : MonoBehaviour
{
    public GameObject cartagutts; //aqui pongo la carta del efecto de gutts
    public List<GameObject> CardsinFrange; //la lista de las cartas en la franja
    public GameObject CementerioGutts;
    public GameObject CementerioGriffith;
    public GameObject CuerpoaCuerpo; //franja de cuerpo a cuerpo de gutts para jugar a su efecto
    public int Cartas = 0; //el .count de la lista
    public int Suma = 0; //la suma del poder de las cartas
    public Text puntuationText; //el textonde va la suma
    public string Faction;
    public int franja;
    public bool AfectadoPorClima = false;//booleano para activar el eclipse
    public bool AfectadoPorAumento = false;//booleano par activar la furia
    public int cantMule = 0;
    public int compMule = 0;

    private GameObject Cardentry;//objeto que colisiona
    private GameObject PlayerHand;//las manos
    private GameObject EnemyHand;
    private int ComprobadordeRonda = 1;
    private int Ronda = 1;
    private bool efectogrunbeld;//booleano para parar la habilidad de grunbeld
    private int sumaparcial = 0;
    private bool selected = false; //para que no se ejecute el efecto sin que se hayan aceptado las cartas 

     private void OnCollisionEnter2D(Collision2D collision) //cuando colisionan mete las cartas en la lista de la franja 
    {
        Cardentry = collision.gameObject;
        CardsinFrange.Add(Cardentry);
        Cartas += 1;
    }
    public void Grunbeld()
    {
      foreach(GameObject Card in CardsinFrange) //si las cartas son de plata les suma 2
      {
        if(Card.GetComponent<ClaseCarta>().Type == "plata")
         {Card.GetComponent<ClaseCarta>().Power +=2;}
      }
    }
    public void Gutts()
    {
        foreach(GameObject Carta in CardsinFrange)
        {
            if(Carta.GetComponent<ClaseCarta>().Name == "Casca")//si en la franja esta una casca instancio la carta del efecto y la muevo a la zona
            {
                GameObject Gutts = Instantiate(cartagutts, new Vector2(0,0), Quaternion.identity);
                Gutts.GetComponent<JugarCarta>().jugable = false;
                Gutts.transform.SetParent(CuerpoaCuerpo.transform, false);
                Gutts.transform.position = CuerpoaCuerpo.transform.position;
                Cartas += 1;
                return;
            }
        }
    }

    public int  Casca()
    {
        if(CardsinFrange.Count >= 1)
        {
        int menor = CardsinFrange[0].GetComponent<ClaseCarta>().Power; // saca la carta con menos poder
            for(int i = 0; i < CardsinFrange.Count; i++)
            {
                menor = Mathf.Min(menor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
            }
        return menor;
        }
        else{return 3000;} // si la franja esta vacia devuelve 3000
    }

    public void AplicarCasca(int puntos)
    {
        foreach (var card in CardsinFrange) //si coincide alguna carta con el parametro que recibe, la manda al cementerio
        {
            if(card.GetComponent<ClaseCarta>().Power == puntos)
            {
                card.transform.position = CementerioGriffith.transform.position;
                card.transform.SetParent(CementerioGriffith.transform, true);
                CardsinFrange.Remove(card);
                Cartas -= 1;
                return;
            }
        }
    }

    public void SkelletonKnight()
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            int Rand = Random.Range(0, CardsinFrange.Count);
            CardsinFrange[Rand].transform.position = CementerioGriffith.transform.position;
            CardsinFrange[Rand].transform.SetParent(CementerioGriffith.transform, true);
            CardsinFrange.Remove(CardsinFrange[Rand]);
            
                Cartas -= 1;
        }
    }
    public void Irvine()
    {
               Debug.Log("pincha");
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            int menor = CardsinFrange[0].GetComponent<ClaseCarta>().Power; // es lo mismo que griffith
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
                    return;
                }
            }
            
                Cartas -= 1;
        }
    }
    public int Danan() //con este metodo primero sumo todas las cartas de la franja y lo devuelvo para utilizarlo en otro script
    {
        int promedio = 0;
        foreach(GameObject carta in CardsinFrange)
        {
            promedio += carta.GetComponent<ClaseCarta>().Power;
        }
        return promedio;
    }
    public void AplicarDanan(int poder) //este poder que recibe es el promedio de todas las cartas del campo  y lo que hace es igualarlas a eso
    {
        foreach(GameObject carta in CardsinFrange)
        {
            carta.GetComponent<ClaseCarta>().Power = poder;
        }
    }
    public void Flora()
    {
        foreach(GameObject Carta in CardsinFrange) //busca si hay una shierke y si esta le suma 2 de poder, pero solo a una
        {
            if(Carta.GetComponent<ClaseCarta>().Name == "Shierke" && Carta.GetComponent<ClaseCarta>().ShierkeAfectada == false)
            {
                Carta.GetComponent<ClaseCarta>().Power += 2;
                Carta.GetComponent<ClaseCarta>().ShierkeAfectada = true; //esto es para que otra flora no afecte a la misma shierke
                break;
            }
        }
    }
    public void Zodd(int Franja) //esta franja es el count de la franja con menos cartas distintas de 0
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            if(CardsinFrange.Count < 4)
            {
               Debug.Log("pincha");
                if(CardsinFrange.Count == Franja)
                {
                foreach(GameObject carta in CardsinFrange) //manda al cementerio todas las cartas de la lista y la vacia
                {
                    carta.transform.position = CementerioGutts.transform.position;
                    carta.transform.SetParent(CementerioGutts.transform, true);
                }
                CardsinFrange.Clear();
                }
            }
            
                Cartas = 0;
        }
    }
    public void Eclipse()
    {
        AfectadoPorClima = true;
    }
    public void Furia()
    {
        AfectadoPorAumento = true;
    }
    public void Amanecer() //arregla todo el desmadre que hizo el eclipse, la furia no la elimino en el otr script para que se siga afectando
    {
        AfectadoPorClima = false;
        foreach(GameObject card in CardsinFrange)
        {
            card.GetComponent<ClaseCarta>().WeatherEffect = false;
            card.GetComponent<ClaseCarta>().BustEffect = false; //para que se pueda afectar de nuevo por la furia
            card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower;
        }
    }
    public void Puck()
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
        int mayor = CardsinFrange[0].GetComponent<ClaseCarta>().Power;
        for(int i = 0; i < CardsinFrange.Count; i++) // busca al mayor
        {
            mayor = Mathf.Max(mayor, CardsinFrange[i].GetComponent<ClaseCarta>().Power);
        }
        foreach(GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Power == mayor && card.GetComponent<ClaseCarta>().Faction == "Sacrificios") //si el mayor es de sacrificios
            {
                card.transform.SetParent(PlayerHand.transform, false); // cabio su posicion a la mano que le toca
                card.transform.position = PlayerHand.transform.position;
                card.GetComponent<JugarCarta>().jugable = true; //hago que se pueda jugar de nuevo, que la afecten los climas, el aumento y pongo su poder original
                card.GetComponent<ClaseCarta>().WeatherEffect = false;
                card.GetComponent<ClaseCarta>().BustEffect = false;
                card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower;
                CardsinFrange.Remove(card);
                return;
            }
            if(card.GetComponent<ClaseCarta>().Power == mayor && card.GetComponent<ClaseCarta>().Faction == "Falconia") // lo mismo
            {
                card.transform.SetParent(EnemyHand.transform, false);
                card.transform.position = EnemyHand.transform.position;
                card.GetComponent<JugarCarta>().jugable = true;
                card.GetComponent<ClaseCarta>().WeatherEffect = false;
                card.GetComponent<ClaseCarta>().BustEffect = false;
                card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower;
                CardsinFrange.Remove(card);
                return;
            }
        }
        }
    }
    public int Ejercitos()
    {
        int CantCartas = 1;

        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
        foreach (GameObject card in CardsinFrange) //para el ejercito de gutts le sumo 1 por cada carta de ejercito en la franja ya
        {
            if(card.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón")
            {
                CantCartas +=1;
            }
        }

        foreach (GameObject card in CardsinFrange) // lo mismo
        {
            if(card.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco")
            {
                CantCartas +=1;
            }
        }
        }
        
        return CantCartas;
    }
    public void AplicarEjercitos() //en este metodo hago lo mismo pero aqui despues multiplico el poder original de la carta por la cantidad de cartas que hay
    {
        int CantCartas = 1;

        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
        foreach (GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón")
            {
                CantCartas +=1;
            }
        }
        foreach (GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Soldados de la banda del Halcón")
            {
                card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower * CantCartas;
            }
        }

        foreach (GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco")
            {
                CantCartas +=1;
            }
        }
        foreach (GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Ejército Demoníaco")
            {
                card.GetComponent<ClaseCarta>().Power = card.GetComponent<ClaseCarta>().OriginalPower * CantCartas;
            }
        }
        }
    }
    public int ObtenerMayor()
    {
        int mayor = 0;
        foreach(GameObject carta in CardsinFrange) //literal obtener el mayor
        {
            mayor = Mathf.Max(mayor, carta.GetComponent<ClaseCarta>().Power);
        }
        return mayor;
    }

    public void EliminarMayor(int puntos)
    {
        if(CardsinFrange.Count == 1 || CardsinFrange.Count > 1)
        {
            foreach(GameObject card in CardsinFrange)
            {
                if(card.GetComponent<ClaseCarta>().Power == puntos && Faction == "Sacrificios") //si la carta carta mayor es de sacrificios lo manda al primer cementerio
                {
                    card.transform.position = CementerioGutts.transform.position;
                    card.transform.SetParent(CementerioGutts.transform, true);
                    CardsinFrange.Remove(card);
                    return;
                }
                else if(card.GetComponent<ClaseCarta>().Power == puntos && Faction == "Falconia") // sino, lo manda al segundo
                {
                    card.transform.position = CementerioGriffith.transform.position;
                    card.transform.SetParent(CementerioGriffith.transform, true);
                    CardsinFrange.Remove(card);
                    return;
                }
            }
        }
    }
    
    void Start()
    {
        cantMule = 0;
        compMule = 0;
    }
    void Update() //lo tengo todo muy regado aqui
    {
        selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected; //busco el booleano para no usar a grunbeld desde antes de elegir
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
            //aqui reinicio la franja para que pueda ser afectada por climas o aumentos
            AfectadoPorAumento = false;
            AfectadoPorClima = false;
            cantMule = 0;
            compMule = 0;
        }
 
        //efecto de grunbeld
        foreach(GameObject card in CardsinFrange)
        {
            if(card.GetComponent<ClaseCarta>().Name == "Grunbeld, El Dragón de Fuego" && efectogrunbeld && selected)
            {
                efectogrunbeld = false;
               Grunbeld();
            }
        }

        //efecto Mule
        compMule = 0;
        foreach (GameObject item in CardsinFrange) //busco por todas las cartas de la franja y guardo la cantidad de mule
        {
            if(item.GetComponent<ClaseCarta>().Name == "Mule Wolflame")
            {
                compMule += 1;
            }
        }
        cantMule = compMule;
        if(cantMule >= 2)
        {
        foreach(GameObject card in CardsinFrange) //si son 2 o mas le doy 3 de poder
            if(card.GetComponent<ClaseCarta>().Name == "Mule Wolflame" && selected)
            {
                card.GetComponent<ClaseCarta>().Power = 3;
            }
        }
        else if(cantMule == 1)
        {
            foreach(GameObject card in CardsinFrange)  //sino la vuelvo 1
        {
            if(card.GetComponent<ClaseCarta>().Name == "Mule Wolflame" && selected)
            {
                card.GetComponent<ClaseCarta>().Power = 1;
            }
        }
        }
        

        //efecto continuo de Clima
        if(AfectadoPorClima)
        {
            foreach(GameObject carta in CardsinFrange)
          {
            if(carta.GetComponent<ClaseCarta>().Type != "oro" && carta.GetComponent<ClaseCarta>().WeatherEffect == false) // si no es de oro y no esta afectada ya la vuelve 1
            {
                carta.GetComponent<ClaseCarta>().WeatherEffect = true;
                carta.GetComponent<ClaseCarta>().Power = 1;
            }
          }
        }

        //efecto continuo de aumento
        if(AfectadoPorAumento)
        {
            foreach(GameObject card in CardsinFrange)
          {
            if(card.GetComponent<ClaseCarta>().Type != "oro" && card.GetComponent<ClaseCarta>().BustEffect == false) //si no es de oro y no esta afectada le suma 1
            {
                card.GetComponent<ClaseCarta>().BustEffect = true;
                card.GetComponent<ClaseCarta>().Power += 1;
            }
          }
        }
    }
}
