using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorL : MonoBehaviour
{
    [SerializeField] public Animator doorL = null;
    [SerializeField] IsLoadedL myLoadedL;
    [SerializeField] AudioSource slideDoor;

    public void OnTriggerEnter(Collider other)
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

    public void OnTriggerExit(Collider other)
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
