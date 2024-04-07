using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffithHabilidad : MonoBehaviour
{
    public ClaseFranja CC; 
    public ClaseFranja D; 
    public ClaseFranja S; 
    public bool turn;

    public bool Usada = false;

    public void Efecto()
    {
        if(Usada == false && turn == false)
        {
            CC.Griffith();
            D.Griffith();
            S.Griffith();
            Usada = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>();
        D = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        S = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>();
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
