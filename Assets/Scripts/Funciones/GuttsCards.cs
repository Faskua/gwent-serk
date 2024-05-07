using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuttsCards : MonoBehaviour
{
    public bool GuttsSelected = false;
    public SetTurn TurnManager;
    private GameObject Background;
    private bool PRobo = false;
    

    
    void Start()
    {
        TurnManager = GameObject.FindGameObjectWithTag("TurnCounter").GetComponent<SetTurn>();
        Background = GameObject.Find("Big Background");
    }

    void Update()
    {
        PRobo = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
    }

    public void SelectCards()
    {
        if(PRobo)
        {
            GuttsSelected = true;
            gameObject.transform.SetParent(Background.transform, false);
            TurnManager.Turno = false;
        }
    }
}
