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

    public void Efecto()
    {
        selected = GameObject.Find("CartasGriffith").GetComponent<GriffCards>().GrifSelected;
        if(jugable && selected)
        {
            GameObject Card = Instantiate(furia, new Vector2(0,0), Quaternion.identity);//se instancia el aumento y se mueve a la franja
            Card.transform.SetParent(meleeClimage.transform, false);
            Card.transform.position = meleeClimage.transform.position;
            EnemyMelee.Furia();
        }
    }

    void Start()
    {
        meleeClimage = GameObject.Find("eMeleeClimage");
        jugable = gameObject.GetComponent<JugarCarta>().jugable;
        EnemyMelee = GameObject.FindGameObjectWithTag("EnemyMelee").GetComponent<ClaseFranja>();
    }
}
