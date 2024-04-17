using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffithHabilidad : MonoBehaviour
{
    public ClaseCementerio cementerioGriff;
    public bool turn;
    public bool Usada = false;

    private bool selected = false;


    public void Efecto()
    {
        if(Usada == false && turn == false && selected)
        {
            cementerioGriff.RegresarMuerto();
            Usada = true; //cambia el booleano de usable
        }
    }

    void Update()
    {
        selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        cementerioGriff = GameObject.FindGameObjectWithTag("EnemyCemetery").GetComponent<ClaseCementerio>();
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
