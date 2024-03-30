using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuttsHabilidad : MonoBehaviour
{
    public GameObject carta;
    public GameObject CuerpoaCuerpo;
    private bool Utilizada = false;
    private bool turn;

    public void Habilidad()
    {
        if(Utilizada == false && turn)
        {
            GameObject Gutts = Instantiate(carta, new Vector2(0,0), Quaternion.identity);
            Gutts.transform.SetParent(CuerpoaCuerpo.transform, false);
            Gutts.transform.position = CuerpoaCuerpo.transform.position;
            Utilizada = true;
        }
    }

    void Update()
    {
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
