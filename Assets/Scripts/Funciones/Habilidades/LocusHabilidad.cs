using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocusHabilidad : MonoBehaviour
{
    public GameObject furia;
    public GameObject meleeClimage;
    public ClaseFranja EnemyMelee;
    private bool jugable;
    private bool selected = false;
    private bool Turn;

    public void Efecto()
    {
        selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        if(jugable && selected && Turn == false)
        {
            GameObject Card = Instantiate(furia, new Vector2(0,0), Quaternion.identity);//se instancia el aumento y se mueve a la franja
            Card.transform.SetParent(meleeClimage.transform, false);
            Card.transform.position = meleeClimage.transform.position;
            Card.GetComponent<JugarCarta>().jugable = false;
            EnemyMelee.Furia();
        }
    }

    void Start()
    {
        Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        meleeClimage = GameObject.Find("eMeleeClimage");
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        EnemyMelee = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
    }
}
