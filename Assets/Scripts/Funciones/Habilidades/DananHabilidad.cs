using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DananHabilidad : MonoBehaviour
{
    public ClaseFranja pCC; //las franjas
    public ClaseFranja pD;
    public ClaseFranja pS;
    public ClaseFranja eCC;
    public ClaseFranja eD;
    public ClaseFranja eS;
    public bool jugable;
    private bool selected = false;
    private bool Turn;
    

    public void Efecto()
    {
        if(jugable && selected && Turn)
        {
            //cant de poder en cada franja
            int p1 = pCC.Suma;
            int p2 = pD.Suma;
            int p3 = pS.Suma;
            int p4 = eCC.Suma;
            int p5 = eD.Suma;
            int p6 = eS.Suma;
            //cant de cartas
            int C1 = pCC.Cartas;
            int C2 = pD.Cartas;
            int C3 = pS.Cartas;
            int C4 = eCC.Cartas;
            int C5 = eD.Cartas;
            int C6 = eS.Cartas;

            //promedio
            int poder = (p1 + p2 + p3 + p4 + p5 + p6)/(C1 + C2 + C3 + C4 + C5 + C6);

            pCC.AplicarDanan(poder);
            pD.AplicarDanan(poder);
            pS.AplicarDanan(poder);
            eCC.AplicarDanan(poder);
            eD.AplicarDanan(poder);
            eS.AplicarDanan(poder);

        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
