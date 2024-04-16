using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Ronda = 1;
    public SetTurn Turn;
    public Text WinsGuttsText; //guarda la cant de victorias de gutts
    public string PointsGutts; //la cantidad de puntos totales de gutts
    public Text WinsGriffithText; // lo mismo con  griffith
    public string PointsGriffith;
    public string GanadorRondas; //guarda al gandor de la primera y segunda ronda
    public Text nextround; // el texto que dice quien comienza


    public bool playerRendido; 
    public bool enemyRendido;
    public bool PartidaTerminada = false;
    private int VictoriasGutts = 0; //el num que pongo en el texto
    private int VictoriasGriffith = 0;
    private int Mano1; //la cantidad de cartas que tienen las manos
    private int Mano2;
    private bool Eroba; //los booleanos para ver si robaron
    private bool Eroba2;
    private bool Eroba3;
    private bool Proba;
    private bool Proba2;
    private bool Proba3;
    private Animator animnext; //el animator del texto
    
    private bool griffElige; //los booleanos que guardan si los jugadores eligieron sus cartas
    private bool guttsElige;


    void Awake()
    {
        GanadorRondas = "nadie";
        animnext = nextround.GetComponent<Animator>(); //buscando el animator del texto
        Turn = GameObject.FindGameObjectWithTag("TurnCounter").GetComponent<SetTurn>(); //buscando el script que guarda los turnos en el objeto turncounter
    }


    public void WhoWon()
    {               //primera ronda
        if(Ronda == 1 && Mano1 == 0 && Mano2 == 0 && Proba && Eroba && guttsElige && griffElige) // ninguno tiene cartas
        {
            int ptsGutts = int.Parse(PointsGutts); //convierto los numeros de los contadores a int y los comparo
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith) //si gutts tiene mas le sumo la victoria en el texto, cambio el turno y cambio el string del texto
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "1raGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts) // lo mismo
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "1raGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext"); // le doy play a la animacion
        }
        if(Ronda == 1 && playerRendido && enemyRendido && Proba && Eroba && guttsElige && griffElige) //ambos se rindieron
        {
            int ptsGutts = int.Parse(PointsGutts);  //estoy haciendo lo mismo para todos los casos
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "1raGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "1raGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }
        if(Ronda == 1 && playerRendido && Mano2 == 0 && Proba && Eroba && guttsElige && griffElige)  //gutts se rindio y griffith no tiene cartas
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "1raGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "1raGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }
        if(Ronda == 1 && Mano1 == 0 && enemyRendido && Proba && Eroba && guttsElige && griffElige)  //gutts no tiene cartas y griffith se rindio
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "1raGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "1raGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }

                    //segunda ronda
        if(Ronda == 2 && Mano1 == 0 && Mano2 == 0 && Proba2 && Eroba2 && guttsElige && griffElige) //lo mismo
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith); //se repite el proceso para todas las rondas
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "2daGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "2daGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }
        if(Ronda == 2 && playerRendido && enemyRendido && Proba2 && Eroba2 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "2daGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "2daGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }
        if(Ronda == 2 && playerRendido && Mano2 == 0 && Proba2 && Eroba2 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "2daGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "2daGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }
        if(Ronda == 2 && Mano1 == 0 && enemyRendido && Proba2 && Eroba2 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = "2daGutts";
                Turn.Turno = true;
                nextround.text = "Comienza Gutts";
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = "2daGriffith";
                Turn.Turno = false;
                nextround.text = "Comienza Griffith";
            }
            Ronda += 1;
            animnext.SetTrigger("shownext");
        }

                    //tercera ronda
        if(Ronda == 3 && Mano1 == 0 && Mano2 == 0 && Proba3 && Eroba3 && guttsElige && griffElige) // again
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && playerRendido && enemyRendido && Proba3 && Eroba3 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && playerRendido && Mano2 == 0 && Proba3 && Eroba3 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
         if(Ronda == 3 && Mano1 == 0 && enemyRendido && Proba3 && Eroba3 && guttsElige && griffElige)
        {
            int ptsGutts = int.Parse(PointsGutts);
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith)
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
            }

            if(ptsGriffith >= ptsGutts)
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
            }
            Ronda = 0;
        }
    }
  
    void Update()
    {
        guttsElige = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected; //busco los booleanos que guardan si eligieron en el boton que esta en la escena
        griffElige = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;

        Mano1 = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().Cartas; //busco la cant de cartas en sus respectivas manos
        Mano2 = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().Cartas;

        playerRendido = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().rendido; // busco los bolleas de rendirse tambien en sus respectivas manos
        enemyRendido = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().rendido;


        PointsGutts = GameObject.Find("ContGutts").GetComponent<Text>().text; //la cant de puntos la busco en el contador general de cada uno
        PointsGriffith = GameObject.Find("ContGriffith").GetComponent<Text>().text;

        Eroba = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;  // los booleanos estos
        Proba = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
        Eroba2 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo2;
        Proba2 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo2;
        Eroba3 = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo3;
        Proba3 = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo3;



                    //Decidiendo el ganador
        if(PartidaTerminada == false && VictoriasGutts == VictoriasGriffith && VictoriasGriffith == 2) //para que si empatan los mande a la escena de empate
        {
            PartidaTerminada = true;
            SceneManager.LoadScene(10);
        }
        else if(PartidaTerminada == false && VictoriasGutts == 2) // en el momento en que llegue gutts a 2 victorias cambio a la escena de gana gutts
        {
            PartidaTerminada = true;
            SceneManager.LoadScene(8);
        }
        else if(PartidaTerminada == false && VictoriasGriffith == 2) // cambio a la escena de gana griffith
        {
            PartidaTerminada = true;
            SceneManager.LoadScene(9);
        }
    }
}
