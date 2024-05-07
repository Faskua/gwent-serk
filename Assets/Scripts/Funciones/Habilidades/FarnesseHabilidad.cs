using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarnesseHabilidad : MonoBehaviour
{
    public GameObject DistanciaClima;//el clima que se instancia
    public GameObject Clima;//la franja
    public ClaseFranja eD;
    public ClaseFranja pD;
    private bool jugable;
    private bool selected = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable && selected && Turn)
        {
        GameObject Carta = Instantiate(Clima, new Vector2(0,0), Quaternion.identity);//se instancia el climay se mueve a la franja
        Carta.transform.SetParent(DistanciaClima.transform, false);
        Carta.transform.position = DistanciaClima.transform.position;
        Carta.GetComponent<JugarCarta>().jugable = false;
        pD.Eclipse();//se activa el efecto de clima en las franjas
        eD.Eclipse();
        }
    }

    void Start()
    {
        DistanciaClima = GameObject.Find("pDistanceClimage");
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
        eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
    }
}
