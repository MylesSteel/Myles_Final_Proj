using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorL : MonoBehaviour
{
    [SerializeField] public Animator doorL = null;              //refrence to aniomator component. 
    [SerializeField] IsLoadedL myLoadedL;                       //refrence to IsLoaded bool
    [SerializeField] AudioSource slideDoor;

    public void OnTriggerEnter(Collider other)           //on trigger enter play door open animation component clip.
                                                         //If cannon is not loaded these animation will play.
    {
        if (other.CompareTag("Player"))
        {
            if (!myLoadedL.isLoaded)
            {
                doorL.Play("door left open", 0, 0.0f);
                slideDoor.Play();
            }
        }
    }

    public void OnTriggerExit(Collider other)         //on trigger exit play door close animation component clip
    {
        if (other.CompareTag("Player"))
        {
            if (!myLoadedL.isLoaded)
            {
                doorL.Play("door left close", 0, 0.0f);
                slideDoor.Play();
            }

        }
    }
}
