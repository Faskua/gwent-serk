using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelletonKnightHabilidad : MonoBehaviour
{
   public ClaseFranja EnemyCC;
   public ClaseFranja EnemyD;
   public ClaseFranja EnemyS;
   public bool jugable; 
   private bool selected = false; 

    public void Efecto()
    {
        int RandIndex = Random.Range(1, 3); //creo un numero random del 1 al 3
        if(jugable && selected)
        {
            if(RandIndex == 1 && EnemyCC.Cartas != 0)
            {
                EnemyCC.SkelletonKnight();
                return;
            }//llama al metodo de skelletonknight en la clasefranja
            else if(RandIndex == 2 && EnemyD.Cartas !=0)
            {
                EnemyD.SkelletonKnight();
                return;
            }
            else if(RandIndex == 3 && EnemyS.Cartas != 0)
            {
                EnemyS.SkelletonKnight();
                return;
            }
            else if(EnemyCC.Cartas != 0)
            {
                EnemyCC.SkelletonKnight();
                return;
            }
            else if(EnemyD.Cartas !=0)
            {
                EnemyD.SkelletonKnight();
                return;
            }
            else if(EnemyS.Cartas != 0)
            {
                EnemyS.SkelletonKnight();
                return;
            }
        }
    }
    
    void Update()
    {
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        EnemyCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
        EnemyD = GameObject.FindGameObjectWithTag("EnemyDistance").GetComponent<ClaseFranja>();
        EnemyS = GameObject.FindGameObjectWithTag("EnemySiege").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
