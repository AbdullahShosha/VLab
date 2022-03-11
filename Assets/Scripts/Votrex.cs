using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Votrex : MonoBehaviour
{
    public static bool Vortexon;

    public void TurnOnAndOff()
    {
        Vortexon = !Vortexon;
        gameObject.GetComponent<Animator>().SetBool("IsWorking", Vortexon);
        if (Vortexon)
            gameObject.GetComponent<AudioSource>().Play();
        else gameObject.GetComponent<AudioSource>().Stop();

    }
    
}
