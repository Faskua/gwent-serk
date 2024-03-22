using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eDrawCards : MonoBehaviour
{
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card15;
    public GameObject Card16;
    public GameObject Card17;
    public GameObject Card18;
    public GameObject Card19;
    public GameObject Card20;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject Card25;
    public GameObject Card26;
    public GameObject Card27;
    public GameObject Card28;
    public GameObject Card29;
    public GameObject Card30;
    public GameObject Card31;
    public GameObject Card32;
    public GameObject Card33;
    public GameObject Card34;
    public GameObject Card35;
    public GameObject Card36;

    public GameObject Hand;

    public List <GameObject> Mazo = new List <GameObject>();


    public void Clicked()
    {
        for (int i= 0; i < 10; i ++)
        {
            GameObject card = Instantiate(Mazo[Random.Range(0,Mazo.Count)], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(Hand.transform, false);
           // Mazo.RemoveAt(0);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
        Mazo.Add(Card1);
        Mazo.Add(Card2);
        Mazo.Add(Card3);
        Mazo.Add(Card4);
        Mazo.Add(Card5);
        Mazo.Add(Card6);
        Mazo.Add(Card7);
        Mazo.Add(Card8);
        Mazo.Add(Card9);
        Mazo.Add(Card10);
        Mazo.Add(Card11);
        Mazo.Add(Card12);
        Mazo.Add(Card13);
        Mazo.Add(Card14);
        Mazo.Add(Card15);
        Mazo.Add(Card16);
        Mazo.Add(Card17);
        Mazo.Add(Card18);
        Mazo.Add(Card19);
        Mazo.Add(Card20);
        Mazo.Add(Card21);
        Mazo.Add(Card22);
        Mazo.Add(Card23);
        Mazo.Add(Card24);
        Mazo.Add(Card25);
        Mazo.Add(Card26);
        Mazo.Add(Card27);
        Mazo.Add(Card28);
        Mazo.Add(Card29);
        Mazo.Add(Card30);
        Mazo.Add(Card31);
        Mazo.Add(Card32);
        Mazo.Add(Card33);
        Mazo.Add(Card34);
        Mazo.Add(Card35);
        Mazo.Add(Card36);

        // Shuffle(Mazo); //las barajeo desde el principio
       
    }


    // public static void Shuffle(List<GameObject> baraja) //metodo pra barajear las cartas del mazo 
    // {
    //     var n = baraja.Count;
    //     var rnd = new Random();
    //     for( int i = n - 1; i>0; i--)
    //     {
    //         var j = rnd.Next(0,i);
    //         var temp = baraja[i];
    //         baraja[i] = baraja[j];
    //         baraja[j] = temp;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
