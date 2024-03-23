using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EClimageMelee : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;
    private bool jugable = true;

    // Start is called before the first frame update
    void Start()
    {
        Zone = GameObject.Find("eMeleeClimage");
    }

    public void PlayCard()
    {
        if(jugable)
        {
        Card.transform.SetParent(Zone.transform, true);
        Card.transform.position = Zone.transform.position;
        jugable = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
