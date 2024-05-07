using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrvineHabilidad : MonoBehaviour
{
    public bool jugable;
    public ClaseFranja PlayerD;
    private bool selected = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable && selected  && Turn == false)
        {
            PlayerD.Irvine(); //lama al metodo de de irvine dentro de clase franja
        }
    }
    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        PlayerD = GameObject.FindGameObjectWithTag("PlayerDistance").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
