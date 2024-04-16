using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuttsHabilidad : MonoBehaviour
{
    public ClaseFranja CC;
    public bool Utilizada = false;
    public bool turn;
    private bool selected;
    private AudioSource soundeffect;//efecto de jugar

    void Start()
    {
        soundeffect = gameObject.GetComponent<AudioSource>();
    }

    public void Habilidad()
    {
        if(Utilizada == false && turn && selected)
        {
            soundeffect.Play();
            CC.Gutts();//se activa el efecto de gutts en cuerpo a cuerpos
            Utilizada = true;
        }
    }

    void Update()
    {
       selected = GameObject.Find("CartasGutts").GetComponent<GuttsCards>().GuttsSelected;
        turn = GameObject.Find("TurnCounter").GetComponent<SetTurn>().Turno;
        CC = GameObject.FindGameObjectWithTag("PlayerMelee").GetComponent<ClaseFranja>();
    }
}
