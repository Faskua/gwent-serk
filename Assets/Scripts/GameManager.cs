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
    private Animator animnext; //el animator del texto
    
    private bool griffElige; //los booleanos que guardan si los jugadores eligieron sus cartas
    private bool guttsElige;


    void Awake()
    {
        GanadorRondas = "nadie";
        animnext = nextround.GetComponent<Animator>(); //buscando el animator del texto
        Turn = GameObject.FindGameObjectWithTag("TurnCounter").GetComponent<SetTurn>(); //buscando el script que guarda los turnos en el objeto turncounter
    }

    public void Winner(string ganagutts = "1raGutts", string ganagriffith = "1raGriffith", string textogutts = "Comienza Gutts", string textogriffith = "Comienza Grifith")
    {
            int ptsGutts = int.Parse(PointsGutts); //convierto los numeros de los contadores a int y los comparo
            int ptsGriffith = int.Parse(PointsGriffith);
            if(ptsGutts >= ptsGriffith) //si gutts tiene mas le sumo la victoria en el texto, cambio el turno y cambio el string del texto
            {
                VictoriasGutts += 1;
                WinsGuttsText.text = VictoriasGutts.ToString();
                GanadorRondas = ganagutts;
                Turn.Turno = true;
                nextround.text = textogutts;
            }

            if(ptsGriffith >= ptsGutts) // lo mismo
            {
                VictoriasGriffith += 1;
                WinsGriffithText.text = VictoriasGriffith.ToString();
                GanadorRondas = ganagriffith;
                Turn.Turno = false;
                nextround.text = textogriffith;
            }
            Ronda += 1;
            animnext.SetTrigger("shownext"); // le doy play a la animacion
    }
    public void WhoWon()
    {   //3ra Ronda
        if(Ronda == 3 && Mano1 == 0 && Mano2 == 0 && guttsElige && griffElige) // again
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
        else if(Ronda == 3 && playerRendido && enemyRendido && guttsElige && griffElige)
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
        else if(Ronda == 3 && playerRendido && Mano2 == 0 && guttsElige && griffElige)
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
        else if(Ronda == 3 && Mano1 == 0 && enemyRendido && guttsElige && griffElige)
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


                    //segunda ronda
        if(Ronda == 2 && Mano1 == 0 && Mano2 == 0 && guttsElige && griffElige) //lo mismo
        {
            Winner();
        }
        else if(Ronda == 2 && playerRendido && enemyRendido && guttsElige && griffElige)
        {
            Winner();
        }
        else if(Ronda == 2 && playerRendido && Mano2 == 0 && guttsElige && griffElige)
        {
            Winner();
        }
        else if(Ronda == 2 && Mano1 == 0 && enemyRendido && guttsElige && griffElige)
        {
            Winner();
        }

         //primera ronda
        if(Ronda == 1 && Mano1 == 0 && Mano2 == 0 && guttsElige && griffElige) // ninguno tiene cartas
        {
            Winner();
        }
        else if(Ronda == 1 && playerRendido && enemyRendido && guttsElige && griffElige) //ambos se rindieron
        {
            Winner();
        }
        else if(Ronda == 1 && playerRendido && Mano2 == 0 && guttsElige && griffElige)  //gutts se rindio y griffith no tiene cartas
        {
            Winner();
        }
        else if(Ronda == 1 && Mano1 == 0 && enemyRendido && guttsElige && griffElige)  //gutts no tiene cartas y griffith se rindio
        {
            Winner();
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
