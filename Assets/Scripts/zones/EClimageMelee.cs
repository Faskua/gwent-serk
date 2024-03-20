using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EClimageMelee : MonoBehaviour
{
    public GameObject Card;
    public GameObject Zone;

    // Start is called before the first frame update
    void Start()
    {
        Zone = GameObject.Find("eMeleeClimage");
    }

    public void PlayCard()
    {
        Card.transform.SetParent(Zone.transform, true);
        Card.transform.position = Zone.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
