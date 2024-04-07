using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTurn : MonoBehaviour
{
    public int Ronda = 1;
    public bool Turno = true;
    public ClaseMano PlayerHand;
    public ClaseMano EnemyHand;
    public GameObject Bloqueo1;
    public GameObject Bloqueo2;
    public Text GuttsrendidoText;
    public Text GriffithrendidoText;
    public bool Guttsusado;
    public bool Griffithusado;
    private int gutts = 1;
    private int griffith = 1;
    private int Mano1 = 0;
    private int Mano2 = 0;
    private int comparator1 = 0;
    private int comparator2 = 0;
    private RectTransform bloqueo1;
    private RectTransform bloqueo2;

    private bool Eroba;
    private bool Eroba2;
    private bool Eroba3;
    private bool Proba;
    private bool Proba2;
    private bool Proba3;

    private bool Ganador1ra;
    private bool Ganador2da;
    private int rondita = 2;


    void Start()
    {
        bloqueo1 = Bloqueo1.GetComponent<RectTransform>();
        bloqueo2 = Bloqueo2.GetComponent<RectTransform>();
    }


    void Update()
    {
        Ganador1ra = GameObject.Find("GameManager").GetComponent<GameManager>().Ganador1ra;
        Ganador2da = GameObject.Find("GameManager").GetComponent<GameManager>().Ganador2da;

        Guttsusado = GameObject.Find("Gutts").GetComponent<GuttsHabilidad>().Utilizada;
        Griffithusado = GameObject.Find("Griffith").GetComponent<GriffithHabilidad>().Usada;

        PlayerHand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>();
        EnemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();

        Eroba = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;
        Proba = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
        Eroba2 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo2;
        Proba2 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo2;
        Eroba3 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo3;
        Proba3 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo3;

        Ronda = GameObject.Find("GameManager").GetComponent<GameManager>().Ronda;
        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas;
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;

        if(Turno && Guttsusado && gutts == 1) // cambiando el turno cuando se usen las habilidades de jefe
        {
            gutts += 1;
            Turno = false;
        }
        if(Turno == false && Griffithusado && griffith == 1)
        {
            griffith += 1;
            Turno = true;
        }


       if(Turno) //cambio de turno 
       {
        bloqueo2.sizeDelta = new Vector2(0, 0);
        bloqueo1.sizeDelta = new Vector2(550, 55);
        if(Mano1 == 0 && Ronda == 1 && Proba)
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 2 && Proba2)
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 3 && Proba3)
        {
            Turno = false;
        }

        if(comparator1 != Mano1)
        {
            comparator1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false) //cambio de turno
       {
        bloqueo1.sizeDelta = new Vector2(0, 0);
        bloqueo2.sizeDelta = new Vector2(550, 55);
        if(Mano2 == 0 && Ronda == 1 && Eroba)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 2 && Eroba2)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 3 && Eroba3)
        {
            Turno = true;
        }

        if(comparator2 != Mano2)
        {
            comparator2 = Mano2;
            Turno = true;
        }
       }

       if(PlayerHand.rendido) //cuando el jugador se rinda siempre le toca al oponente y aparece el cartel de rendido
        {
            Turno = false;
            GuttsrendidoText.text = "Gutts Se Ha Rendido";
        }
        else
        {
            GuttsrendidoText.text = "";
        }

        if(EnemyHand.rendido)
        {
            Turno = true;
            GriffithrendidoText.text = "Griffith Se Ha Rendido";
        }
        else
        {
            GriffithrendidoText.text = "";
        }
        
        if(EnemyHand.rendido && PlayerHand.rendido) //cuanso se rinden ambos no se pueden ver las cartas de ninguna mano
        {
            bloqueo2.sizeDelta = new Vector2(550, 55);
            bloqueo1.sizeDelta = new Vector2(550, 55);
        }

        //decidiendo de quien es el truno al inicio de la segunda y tercera ronda
        if(Ronda == rondita && Ganador1ra)
        {
            rondita +=1;
            Turno = true;
        }
        else if(Ronda == rondita && Ganador1ra == false)
        {
            rondita +=1;
            Turno = false;
        }
        else if(Ronda == rondita && Ganador2da)
        {
            rondita +=1;
            Turno = true;
        }
        else if(Ronda == rondita && Ganador2da == false)
        {
            rondita +=1;
            Turno = false;
        }
    }
}
