using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCards : MonoBehaviour
{
    //recibo todas las cartas del mazo
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card15;
    public GameObject Card16;
    public GameObject Card17;
    public GameObject Card18;
    public GameObject Card19;
    public GameObject Card20;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject Card25;
    public GameObject Card26;
    public GameObject Card27;
    public GameObject Card28;
    public GameObject Card29;
    public GameObject Card30;
    public GameObject Card31;
    public GameObject Card32;
    public GameObject Card33;
    public GameObject Card34;

    private GameObject Hand;
    private int compCartas = 0;
    public bool robo = false;//los boleanos que controlan si ya robo en cada ronda
    public bool robo2 = false;
    public bool robo3 = false;
    private int Ronda = 1; 
    private int position = 0; //el numero al azar en que se coge la carta
    private Animator animator; //el animator de la baraja
    private AudioSource Seffect; //el sonido
    private bool Turn;

    public List <GameObject> Mazo = new List <GameObject>();


    public void verificadordeCarta() //vaya con recursividad para que vean que soy de los que atiende en las conferencias del profe juan pablo.
    {
        position = Random.Range(0, Mazo.Count);
        if(Mazo[position].GetComponent<ClaseCarta>().repartida == false)//busco la carta en la posicion random de la lista y si no esta repartida la mando a la mano
        {
            GameObject card = Instantiate(Mazo[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(Hand.transform, false);
            Mazo[position].GetComponent<ClaseCarta>().repartida = true;
        }
        else//sino repito proceso hasta que se cumpla
        {
            verificadordeCarta();
        }
    }
    public void AnimClick() //es el metod de click pero mas tarde para darle tiempo a la animacion y el sonido
    {
        if(Turn)
        {animator.SetTrigger("JRepartir");
        Seffect.Play();
        Invoke("OnClick", 1);}
    }
    public void OnClick()
    {
        if(Turn)
        {
            compCartas = Hand.GetComponent<ClaseMano>().Cartas;
        if(robo == false)
        {
        for (int i= 0; i < 10; i ++)
        { 
            if(compCartas < 10)//solo si tiene menos de 10 cartas
            {
            verificadordeCarta();//reparte 10 cartas
            compCartas += 1;
            }
        }
        robo = true;
        }

         if(robo2 == false && Ronda == 2)
        {
        for (int i= 0; i < 2; i ++)
        {
            if(compCartas < 10)
            {
            compCartas += 1;
            verificadordeCarta();//reparte 2
            }
        }
        robo2 = true;
        }

         if(robo3 == false && Ronda == 3)
        {
        for (int i= 0; i < 2; i ++)
        { 
            if(compCartas < 10)
            {
            compCartas += 1;
            verificadordeCarta();
            }//reparte 2
        }
        robo3 = true;
        }
        }
    }


    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        Seffect = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        
        Mazo.Add(Card1);
        Mazo.Add(Card2);
        Mazo.Add(Card3);
        Mazo.Add(Card4);
        Mazo.Add(Card5);
        Mazo.Add(Card6);
        Mazo.Add(Card7);
        Mazo.Add(Card8);
        Mazo.Add(Card9);
        Mazo.Add(Card10);
        Mazo.Add(Card11);
        Mazo.Add(Card12);
        Mazo.Add(Card13);
        Mazo.Add(Card14);
        Mazo.Add(Card15);
        Mazo.Add(Card16);
        Mazo.Add(Card17);
        Mazo.Add(Card18);
        Mazo.Add(Card19);
        Mazo.Add(Card20);
        Mazo.Add(Card21);
        Mazo.Add(Card22);
        Mazo.Add(Card23);
        Mazo.Add(Card24);
        Mazo.Add(Card25);
        Mazo.Add(Card26);
        Mazo.Add(Card27);
        Mazo.Add(Card28);
        Mazo.Add(Card29);
        Mazo.Add(Card30);
        Mazo.Add(Card31);
        Mazo.Add(Card32);
        Mazo.Add(Card33);
        Mazo.Add(Card34);

    foreach(GameObject card in Mazo)//al principio de la partida hace que todas las cartas sean repartibles, y que se pueda usar el metodo de clima y aumento
        {
            card.GetComponent<ClaseCarta>().repartida = false;
            card.GetComponent<ClaseCarta>().BustEffect = false;
            card.GetComponent<ClaseCarta>().WeatherEffect = false;
        }
    }
    void Update()
    {
        Hand = GameObject.Find("PlayerHand");
        Ronda = GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
