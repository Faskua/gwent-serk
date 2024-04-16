using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelletonKnightHabilidad : MonoBehaviour
{
   public ClaseFranja EnemyCC;
   public bool jugable; 
    private bool selected = false; 

    public void Efecto()
    {
        if(jugable && selected)
        {
            EnemyCC.SkelletonKnight();//llama al metodo de skelletonknight e la clasefranja
        }
    }
    
    void Update()
    {
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        EnemyCC = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
