using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarnesseHabilidad : MonoBehaviour
{
    public GameObject DistanciaClima;
    public GameObject Clima;
    public ClaseFranja eD;
    public ClaseFranja pD;
    private bool jugable;

    public void Efecto()
    {
        if(jugable)
        {
        GameObject Carta = Instantiate(Clima, new Vector2(0,0), Quaternion.identity);
        Carta.transform.SetParent(DistanciaClima.transform, false);
        pD.Eclipse();
        eD.Eclipse();
        }
    }

    void Start()
    {
        DistanciaClima = GameObject.Find("pDistanceClimage");
    }

    void Update()
    {
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
        eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
    }
}
