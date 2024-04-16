using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuttsCards : MonoBehaviour
{
    public bool GuttsSelected = false;
    private GameObject Background;
    private bool PRobo = false;

    
    void Start()
    {
        Background = GameObject.Find("Big Background");
    }

    void Update()
    {
        PRobo = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().robo;
    }

    public void SelectCards()
    {
        if(PRobo)
        {GuttsSelected = true;
        gameObject.transform.SetParent(Background.transform, false);}
    }
}
