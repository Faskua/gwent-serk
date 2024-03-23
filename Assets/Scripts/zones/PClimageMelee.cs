using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PClimageMelee : MonoBehaviour
{
    public GameObject Card;
    public GameObject MeleeZone;
    private bool jugable = true;

    // Start is called before the first frame update
    void Start()
    {
        MeleeZone = GameObject.Find("pMeleeClimage");
    }

    public void PlayCard()
    {
        if(jugable)
        {
        Card.transform.SetParent(MeleeZone.transform, true);
        Card.transform.position = MeleeZone.transform.position;
        jugable = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
