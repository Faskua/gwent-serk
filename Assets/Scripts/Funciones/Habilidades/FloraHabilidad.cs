using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloraHabilidad : MonoBehaviour
{
    public ClaseFranja Siege;//la franja de asedio
    public bool jugable;
    private bool selected = false;
    private bool Turn;

    public void Efecto()
    {
        if(jugable && selected && Turn)
        {
            Siege.Flora(); //llama al metodo de flora en clasefranja
            gameObject.GetComponent<ClaseCarta>().Power += 1; //se suma 1 a si misma
        }
    }

    void Update()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        Siege = GameObject.FindGameObjectWithTag("PlayerSiege").GetComponent<ClaseFranja>();
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
    }
}
