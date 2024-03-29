using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarCarta : MonoBehaviour
{
    public GameObject Card; //la carta a jugar
    public bool Turn = true; //controlador del turno
   //las zonas
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
    }

    public void PlayCard()
    {
        if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 1 && Turn == true)
        {
            bool jugable = true;

            if(jugable)
            {
            Card.transform.SetParent(PMelee.transform, false);
            Card.transform.position = PMelee.transform.position;
            jugable = false;
            }
        }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 2 && Turn == true)
         {
            bool jugable = true;
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            }
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 3 && Turn == true)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(PSiege.transform, false);
            Card.transform.position = PSiege.transform.position;
            jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 4 && Turn == true)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(pCmelee.transform, true);
            Card.transform.position = pCmelee.transform.position;
             jugable = false;
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 5 && Turn == true)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(pCdistance.transform, true);
            Card.transform.position = pCdistance.transform.position;
             jugable = false;
            }   
         }

           if(Card.GetComponent<ClaseCarta>().Faction == "Sacrificios" && Card.GetComponent<ClaseCarta>().Frange == 6 && Turn == true)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(pCsiege.transform, true);
            Card.transform.position = pCsiege.transform.position;
             jugable = false;
            }   
         }



            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 1 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(EMelee.transform, false);
            Card.transform.position = EMelee.transform.position;
             jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 2 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 3 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(ESiege.transform, false);
            Card.transform.position = ESiege.transform.position;
             jugable = false;
            }   
         }

             if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 4 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(eCmelee.transform, true);
            Card.transform.position = eCmelee.transform.position;
             jugable = false;
            }   
         }

            if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 5 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(eCdistance.transform, true);
            Card.transform.position = eCdistance.transform.position;
             jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Faction == "Falconia" && Card.GetComponent<ClaseCarta>().Frange == 6 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(eCsiege.transform, true);
            Card.transform.position = eCsiege.transform.position;
             jugable = false;
            }   
         }

               //a partir de aqui es para jugar a la carta espia
         if(Card.GetComponent<ClaseCarta>().Frange == 7 && Turn)  
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 8 && Turn)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(ESiege.transform, false);
            Card.transform.position = ESiege.transform.position;
             jugable = false;
            }   
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 9 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            }
         }

         if(Card.GetComponent<ClaseCarta>().Frange == 10 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(PSiege.transform, false);
            Card.transform.position = PSiege.transform.position;
            jugable = false;
            }   
         }


               //y a partir de aqui es para jugar al sennuelo
          if(Card.GetComponent<ClaseCarta>().Frange == 11 && Turn)
        {
            bool jugable = true;

            if(jugable)
            {
            Card.transform.SetParent(PMelee.transform, false);
            Card.transform.position = PMelee.transform.position;
            jugable = false;
            }
        } 

          if(Card.GetComponent<ClaseCarta>().Frange == 12 && Turn)
         {
            bool jugable = true;
            if(jugable)
            {
                Card.transform.SetParent(PDistance.transform, false);
                Card.transform.position = PDistance.transform.position;
                jugable = false;
            }
         } 

          if(Card.GetComponent<ClaseCarta>().Frange == 13 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(EMelee.transform, false);
            Card.transform.position = EMelee.transform.position;
             jugable = false;
            }   
         }

          if(Card.GetComponent<ClaseCarta>().Frange == 14 && Turn == false)
         {
            bool jugable = true;
            if(jugable)
            {
            Card.transform.SetParent(EDistance.transform, false);
            Card.transform.position = EDistance.transform.position;
             jugable = false;
            }   
         }
    }



    void Update()
    {
      Turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
    }
}
