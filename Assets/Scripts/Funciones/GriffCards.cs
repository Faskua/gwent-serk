using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GriffCards : MonoBehaviour
{
    public bool GrifSelected = false;
    public SetTurn TurnManager;
    private GameObject Background; //el bacground del juego
    private bool ERobo = false;

    void Start()
    {
        TurnManager = GameObject.FindGameObjectWithTag("TurnCounter").GetComponent<SetTurn>();
        Background = GameObject.Find("Big Background");
    }
    void Update()
    {
        ERobo = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().robo;
    }

    public void SelectCards() // si el jugador ya robo  se vuelve verdadero el booleano de ya eligio
    {
        if(ERobo)
        {
            GrifSelected = true;
            gameObject.transform.SetParent(Background.transform, false);
            TurnManager.Turno = true;
        } //se setparentea el boton al bacground para no poder verlo
    }
}
