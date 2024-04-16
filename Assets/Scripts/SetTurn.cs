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
    public GameObject Bloqueo1; //imagen con la que tapo la mano de gutts
    public GameObject Bloqueo2; //imagen con la que tapo la mano de griffith
    public Text GuttsrendidoText;
    public Text GriffithrendidoText;
    public bool Guttsusado; // este y el de abajo es para ver si se usa al lider
    public bool Griffithusado;
    private int gutts = 1; //como el metodo para cambiar el turno si se usa al lider esta en el update, esto es para que se haga una sola vez si le sumo 1
    private int griffith = 1;  //lo mismo
    public int Mano1 = 0; //cantidad de cartas de gutts
    private int Mano2 = 0; //cant de cartas de griffith
    public int comparator1 = 0; //este y el de abajo es para detectar cuando hay una diiferencia en las cartas y cuando la haya cambiar de turno
    private int comparator2 = 0;
    private RectTransform bloqueo1; // para controlar el tamaño de los bloqueos
    private RectTransform bloqueo2;

    private bool Eroba; //estos 6 booleanos son para guardar si los jugadores han robado en cada ronda
    private bool Eroba2;
    private bool Eroba3;
    private bool Proba;
    private bool Proba2;
    private bool Proba3;

    public string Ganadores; // en este string se guarda el ganador de la 1ra y 2da ronda

    private bool griffElige; //este y el de abajo guardan cuando los jugadores se mantienen con las cartas del principio
    private bool guttsElige;
    public int CompRonda = 1; //detectar un cambio de ronda y decir quien empieza


    void Start()
    {
        Ganadores = "nadie";
        bloqueo1 = Bloqueo1.GetComponent<RectTransform>();
        bloqueo2 = Bloqueo2.GetComponent<RectTransform>();
    }

    public void EmpiezaGutts()
    {
        Turno = true;
    }

    public void EmpiezaGriffith()
    {
        Turno = false;
    }


    void Update()
    {
        guttsElige = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected; // los busco en los botones para elegir las cartas
        griffElige = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;

        Ganadores = GameObject.Find("GameManager").GetComponent<GameManager>().GanadorRondas; //se busca en el GameManager

        Guttsusado = GameObject.Find("Gutts").GetComponent<GuttsHabilidad>().Utilizada; //se busca en las cartas de lider
        Griffithusado = GameObject.Find("Griffith").GetComponent<GriffithHabilidad>().Usada;

        PlayerHand = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>(); // buscando la mano propia y rival
        EnemyHand = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();

        Eroba = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo; // los booleanos que controlan si ha robado se buscan en los mazos
        Proba = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
        Eroba2 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo2;
        Proba2 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo2;
        Eroba3 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo3;
        Proba3 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo3;

        Ronda = GameObject.Find("GameManager").GetComponent<GameManager>().Ronda; //la ronda la busco en el gamemanager
        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas; //mirando la cant de cartas en las manos
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;


        if(Turno && Guttsusado && gutts == 1 && guttsElige) // cambiando el turno cuando se usen las habilidades de jefe
        {
            gutts += 1;
            Turno = false;
        }
        if(Turno == false && Griffithusado && griffith == 1 && griffElige)
        {
            griffith += 1;
            Turno = true;
        }


       if(Turno) //cambio de turno 
       {
        bloqueo2.sizeDelta = new Vector2(0, 0);
        bloqueo1.sizeDelta = new Vector2(550, 55);// aqui cambio el size del bloque para que el oponente no vea tus cartas
        if(Mano1 == 0 && Ronda == 1 && Proba && guttsElige) //esto es para cuando te quedes sin cartas le toque solo al oponente y lo repito para cada ronda
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 2 && Proba2 && guttsElige)
        {
            Turno = false;
        }
        if(Mano1 == 0 && Ronda == 3 && Proba3 && guttsElige)
        {
            Turno = false;
        }

        if(comparator1 != Mano1 && guttsElige) // si detecta que hay una diferencia en las cartas es que se ha jugado  y cambia el turno
        {
            comparator1 = Mano1;
            Turno = false;
        }
       }


       if(Turno == false) //cambio de turno y repito lo mismo de arriba
       {
        bloqueo1.sizeDelta = new Vector2(0, 0);
        bloqueo2.sizeDelta = new Vector2(550, 55); 
        if(Mano2 == 0 && Ronda == 1 && Eroba && griffElige)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 2 && Eroba2 && griffElige)
        {
            Turno = true;
        }
        if(Mano2 == 0 && Ronda == 3 && Eroba3 && griffElige)
        {
            Turno = true;
        }

        if(comparator2 != Mano2 && griffElige)
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
        else //aqui estoy modificando el texto que muestra quien se ha rendido
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
        
        if(EnemyHand.rendido && PlayerHand.rendido) //estos 3 son para que cuando se rinden ambos no se pueden ver las cartas de ninguna mano
        {
            bloqueo2.sizeDelta = new Vector2(550, 55);
            bloqueo1.sizeDelta = new Vector2(550, 55);
        }
        if(EnemyHand.rendido && Mano2 == 0)
        {
            bloqueo2.sizeDelta = new Vector2(550, 55);
            bloqueo1.sizeDelta = new Vector2(550, 55);
        }
        if(Mano1 == 0 && PlayerHand.rendido)
        {
            bloqueo2.sizeDelta = new Vector2(550, 55);
            bloqueo1.sizeDelta = new Vector2(550, 55);
        }

         //decidiendo de quien es el truno al inicio de la segunda y tercera ronda
        if(Ronda != CompRonda && Ganadores == "1raGutts")
        {
            CompRonda = Ronda;
            EmpiezaGutts(); //al final estos metodos los hice por gusto xd
        }
        else if(Ronda != CompRonda && Ganadores == "1raGriffith")
        {
            CompRonda = Ronda;
            EmpiezaGriffith();
        }
        else if(Ronda != CompRonda && Ganadores == "2daGutts")
        {
            CompRonda = Ronda;
            EmpiezaGutts();
        }
        else if(Ronda != CompRonda && Ganadores == "2daGriffith")
        {
            CompRonda = Ronda;
            EmpiezaGriffith();
        }
    }
}
