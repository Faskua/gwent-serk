using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarCarta : MonoBehaviour
{
    public GameObject Card; //la carta a jugar
    public bool Turn = true; //controlador del turno
   public bool jugable = true;
   public bool PartidaTerminada;
   public bool griffithrend;
   public bool guttsrend;

   //las zonas
   public GameObject PHand;
   public GameObject EHand;
    public GameObject PMelee;
    public GameObject PDistance;
    public GameObject PSiege;
    public GameObject EMelee;
    public GameObject EDistance;
    public GameObject ESiege;
    public GameObject pCmelee;
    public GameObject pCdistance;
    public GameObject pCsiege;
    public GameObject eCmelee;
    public GameObject eCdistance;
    public GameObject eCsiege;
    //el objeto que voy a utilizar para tapar la mano enemiga
    public GameObject Bloqueo1;
    public GameObject Bloqueo2;
    private List<GameObject> mazo;
    private List<GameObject> mazoenemigo;
    private int position= 0;
    private AudioSource sound;


    void Start()
    {
        PMelee = GameObject.Find("PlayerMelee");
        PDistance = GameObject.Find("PlayerDistance");
        PSiege = GameObject.Find("PlayerSiege");
        EMelee = GameObject.Find("EnemyMelee");
        EDistance = GameObject.Find("EnemyDistance");
        ESiege = GameObject.Find("EnemySiege");
        pCmelee = GameObject.Find("pMeleeClimage");
        pCdistance = GameObject.Find("pDistanceClimage");
        pCsiege = GameObject.Find("pSiegeClimage");
        eCmelee = GameObject.Find("eMeleeClimage");
        eCdistance = GameObject.Find("eDistanceClimage");
        eCsiege = GameObject.Find("eSiegeClimage");
        PHand = GameObject.Find("PlayerHand");
        EHand = GameObject.Find("EnemyHand");
        PartidaTerminada = GameObject.Find("GameManager").GetComponent<GameManager>().PartidaTerminada;
        sound = gameObject.GetComponent<AudioSource>();
    }

    public void PlayCard()
    {
       if(PartidaTerminada == false)
       {
        if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 1 && Turn == true && guttsrend == false)
        {
            if(jugable)
            {
            Card.transform.SetParent(PMelee.transform, false);
            Card.transform.position = PMelee.transform.position;
            jugable = false;
            sound.Play();
            }
        }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 2 && Turn == true && guttsrend == false)
         {
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            sound.Play();
            }
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 3 && Turn == true && guttsrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(PSiege.transform, false);
            Card.transform.position = PSiege.transform.position;
            jugable = false;
            sound.Play();
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 4 && Turn == true && guttsrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(pCmelee.transform, true);
            Card.transform.position = pCmelee.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 5 && Turn == true && guttsrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(pCdistance.transform, true);
            Card.transform.position = pCdistance.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

           if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 6 && Turn == true && guttsrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(pCsiege.transform, true);
            Card.transform.position = pCsiege.transform.position;
             jugable = false;
            sound.Play();
            }   
         }



            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 1 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(EMelee.transform, false);
            Card.transform.position = EMelee.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 2 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 3 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(ESiege.transform, false);
            Card.transform.position = ESiege.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 4 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(eCmelee.transform, true);
            Card.transform.position = eCmelee.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 5 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(eCdistance.transform, true);
            Card.transform.position = eCdistance.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 6 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(eCsiege.transform, true);
            Card.transform.position = eCsiege.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

               //a partir de aqui es para jugar a la carta espia
         if(Card.GetComponent<ClaseCarta>().Frange == 7 && Turn && guttsrend == false)  
         {
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 8 && Turn && guttsrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(ESiege.transform, false);
            Card.transform.position = ESiege.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 9 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            sound.Play();
            }
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 10 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(PSiege.transform, false);
            Card.transform.position = PSiege.transform.position;
            jugable = false;
            sound.Play();
            }   
         }


               //y a partir de aqui es para jugar al sennuelo
          if(Card.GetComponent<ClaseCarta>().Frange == 11 && Turn && guttsrend == false)
        {
            if(jugable)
            {
            Card.transform.SetParent(PMelee.transform, false);
            Card.transform.position = PMelee.transform.position;
            jugable = false;
            sound.Play();
            }
        } 

          if(Card.GetComponent<ClaseCarta>().Frange == 12 && Turn && guttsrend == false)
         {
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            sound.Play();
            }
         } 

          if(Card.GetComponent<ClaseCarta>().Frange == 13 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(EMelee.transform, false);
            Card.transform.position = EMelee.transform.position;
             jugable = false;
            sound.Play();
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Frange == 14 && Turn == false && griffithrend == false)
         {
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            sound.Play();
            }   
         }
       } 
    }

    public void verificador()
    {
        position = Random.Range(0, mazo.Count);
        if(mazo[position].GetComponent<ClaseCarta>().repartida == false)
        {
            GameObject card = Instantiate(mazo[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(PHand.transform, false);
            mazo[position].GetComponent<ClaseCarta>().repartida = true;
        }
        else
        {
            verificador();
        }
    }
     public void verificadorenemigo() 
    {
        position = Random.Range(0, mazoenemigo.Count);
        if(mazoenemigo[position].GetComponent<ClaseCarta>().repartida == false)
        {
            GameObject card = Instantiate(mazoenemigo[position], new Vector2(0,0), Quaternion.identity);
            card.transform.SetParent(EHand.transform, false);
            mazoenemigo[position].GetComponent<ClaseCarta>().repartida = true;
        }
        else
        {
            verificadorenemigo();
        }
    }
    public void NlunarGutts()
    {
      for(int i = 0; i < 2; i++)
      {
         if(mazo.Count > 2)
         {
            verificador();
         }
      }
    }
    public void NLunarGriffith()
    {
      for(int i = 0; i < 2; i++)
      {
         if(mazoenemigo.Count > 2)
         {
            verificadorenemigo();
         }
      }
    }




    void Update()
    {
      Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
      mazo = GameObject.Find("PlayerDeck").GetComponent<DrawCards>().Mazo;
      mazoenemigo = GameObject.Find("EnemyDeck").GetComponent<eDrawCards>().Mazo;
      griffithrend = GameObject.Find("EnemyHand").GetComponent<ClaseMano>().rendido;
      guttsrend = GameObject.Find("PlayerHand").GetComponent<ClaseMano>().rendido;
    }
}
