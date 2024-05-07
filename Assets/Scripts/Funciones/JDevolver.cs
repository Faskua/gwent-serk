using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDevolver : MonoBehaviour
{
    public ClaseMano manojugador; //las manos y los mazos
    public ClaseMano manoenemiga;
    public DrawCards mazojugador;
    public eDrawCards mazoenemigo;
    public GameObject ZonaDeCarta;
    public GameObject ZonaDeDescrp;
    private SetTurn Turn;
    private bool guttselige;
    private bool griffelige;

    void Start()
    {
        manojugador = GameObject.FindGameObjectWithTag("PlayerHand").GetComponent<ClaseMano>();
        mazojugador = GameObject.FindGameObjectWithTag("PlayerDeck").GetComponent<DrawCards>();
        manoenemiga = GameObject.FindGameObjectWithTag("EnemyHand").GetComponent<ClaseMano>();
        mazoenemigo = GameObject.FindGameObjectWithTag("EnemyDeck").GetComponent<eDrawCards>();
        ZonaDeCarta = GameObject.Find("Rendirse");
        ZonaDeDescrp = GameObject.Find("DescriptionText");
    }

    public void Devolver()//si tocas click derecho se ejcuta
    {
        if(Input.GetMouseButtonUp(1) && manojugador.CartasDevueltas < 2 && Turn.Turno && guttselige == false && gameObject.GetComponent<ClaseCarta>().Faction == "Sacrificios")
        {
            manojugador.CartasDevueltas += 1; //suma 1 al contador de las cartas devueltas
            gameObject.GetComponent<ClaseCarta>().repartida = false;//permite que la carta destruida se pueda robar de nuevo
            mazojugador.verificadordeCarta();//se reparte una carta
            Destroy(gameObject);
            Destroy(ZonaDeCarta.transform.GetChild(0).gameObject);//se destruye la carta, la descripcion y la carta zoomeada y la info
            Destroy(ZonaDeDescrp.transform.GetChild(0).gameObject);
        }

        if(Input.GetMouseButtonUp(1) && manoenemiga.CartasDevueltas < 2 && Turn.Turno == false && griffelige == false && gameObject.GetComponent<ClaseCarta>().Faction == "Falconia")
        {
            manoenemiga.CartasDevueltas += 1;
            gameObject.GetComponent<ClaseCarta>().repartida = false;
            mazoenemigo.verificadordeCarta();
            Destroy(gameObject);
            Destroy(ZonaDeCarta.transform.GetChild(0).gameObject);
            Destroy(ZonaDeDescrp.transform.GetChild(0).gameObject);
        }
    }

    void Update()
    {
        Turn = GameObject.FindGameObjectWithTag("TurnCounter").GetComponent<SetTurn>();
        guttselige = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        griffelige = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
    }
}
