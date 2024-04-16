using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffithHabilidad : MonoBehaviour
{
    public ClaseFranja CC; 
    public ClaseFranja D; 
    public ClaseFranja S; 
    public bool turn;
    private bool selected = false;

    public bool Usada = false;

    public void Efecto()
    {
        if(Usada == false && turn == false && selected)
        {
            CC.Griffith();//activa el metodo de griffith en las 3 franjas del rival para eliminar la menor carta en cada una
            D.Griffith();
            S.Griffith();
            Usada = true; //cambia el booleano de usable
        }
    }

    void Update()
    {
       selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>();
        D = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        S = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>();
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
