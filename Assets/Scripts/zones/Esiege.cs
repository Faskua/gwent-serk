using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esiege : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;
    private bool jugable = true;

    // Start is called before the first frame update
    void Start()
    {
        Zone = GameObject.Find("EnemySiege");
    }

    public void PlayCard()
    {
        if(jugable)
        {
        Card.transform.SetParent(Zone.transform, false);
        Card.transform.position = Zone.transform.position;
        jugable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
