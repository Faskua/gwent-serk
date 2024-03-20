using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmelee : MonoBehaviour
{
    public GameObject Card;
    public GameObject MeleeZone;

    // Start is called before the first frame update
    void Start()
    {
        MeleeZone = GameObject.Find("PlayerMelee");
    }

    public void PlayCard()
    {
        Card.transform.SetParent(MeleeZone.transform, false);
        Card.transform.position = MeleeZone.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
