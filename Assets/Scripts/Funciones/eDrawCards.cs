using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eDrawCards : MonoBehaviour
{//es lo mismo que el drawcards pero para el enemigo
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
    public bool robo = false;
    public bool robo2 = false;
    public bool robo3 = false;
    public Text GanadorText;
    private int Ronda = 1;
    private int position = 0;
    private bool Turn;
    private Animator animator;
    private AudioSource sEffect;

    public List <GameObject> Mazo = new List <GameObject>();

    public void verificadordeCarta() //vaya con recursividad para que vean que soy de los que atiende en las conferencias del profe juan pablo.
    {
        position = Random.Range(0, Mazo.Count);
        if(Mazo[position].GetComponent<ClaseCarta>().repartida == false)
        {
            GameObject card = Instantiate(Mazo[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(Hand.transform, false);
            Mazo[position].GetComponent<ClaseCarta>().repartida = true;
        }
        else
        {
            verificadordeCarta();
        }
    }
    public void AnimClick()
    {
        if( Turn == false )
        {
            animator.SetTrigger("ERepartir");
            sEffect.Play();
            Invoke("Clicked", 1);
        }
    }
    public void Clicked()
    {
        if(Turn == false)
        {
            compCartas = Hand.GetComponent<ClaseMano>().Cartas;
        if(robo == false)
        {
        for (int i= 0; i < 10; i ++)
        {
           if(compCartas < 10)
            {
            verificadordeCarta();
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
            verificadordeCarta();
            compCartas += 1;
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
            verificadordeCarta();
            compCartas += 1;
            }
        }
        robo3 = true;
        }
        }
    }


    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        sEffect = gameObject.GetComponent<AudioSource>();
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

       foreach(GameObject card in Mazo)
        {
            card.GetComponent<ClaseCarta>().BustEffect = false;
            card.GetComponent<ClaseCarta>().WeatherEffect = false;
            card.GetComponent<ClaseCarta>().repartida = false;
        }
        Hand = GameObject.Find("EnemyHand");
       
    }
    void Update()
    {
        Ronda = GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
