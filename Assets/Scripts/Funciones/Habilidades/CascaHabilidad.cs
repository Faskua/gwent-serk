using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CascaHabilidad : MonoBehaviour
{
    public ClaseFranja EnemyCC;
    public ClaseFranja EnemyD;
    public ClaseFranja EnemyS;
    public bool jugable; 
    private bool selected = false; 
    private bool Turn;

     public void Efecto()
     {
        if(Turn)
        {int cc = EnemyCC.Casca(); //recibo la carta mas debil de cada franja
        int d = EnemyD.Casca();
        int s = EnemyS.Casca();
        int menor = Mathf.Min(cc, Mathf.Min(d, s)); // la comparo

        if(d == menor) //y aplico el efecto en la franja
        {
            EnemyD.AplicarCasca(menor);
            return;
        }
        if(cc == menor)
        {
            EnemyCC.AplicarCasca(menor);
            return;
        }
        if(s == menor)
        {
            EnemyS.AplicarCasca(menor);
            return;
        }}
     }


    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        EnemyCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
        EnemyD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>();
        EnemyS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
