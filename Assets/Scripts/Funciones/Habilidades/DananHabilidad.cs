using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DananHabilidad : MonoBehaviour
{
    public ClaseFranja pCC;
    public ClaseFranja pD;
    public ClaseFranja pS;
    public ClaseFranja eCC;
    public ClaseFranja eD;
    public ClaseFranja eS;
    public bool jugable;
    

    public void Efecto()
    {
        if(jugable)
        {
            //cant de poder en cada franja
            int p1 = pCC.Danan();
            int p2 = pD.Danan();
            int p3 = pS.Danan();
            int p4 = eCC.Danan();
            int p5 = eD.Danan();
            int p6 = eS.Danan();
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

            gameObject.GetComponent<ClaseCarta>().Power = poder;
        }
    }

    void Update()
    {
       pCC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>(); 
       pD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>(); 
       pS = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>(); 
       eCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>(); 
       eD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>(); 
       eS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>(); 
       jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
