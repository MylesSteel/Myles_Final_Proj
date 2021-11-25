using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorL : MonoBehaviour
{
    [SerializeField] public Animator doorL = null;
    [SerializeField] IsLoadedL myLoadedL;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!myLoadedL.isLoaded)
            {
                doorL.Play("Open Door L", 0, 0.0f);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!myLoadedL.isLoaded)
            {
                doorL.Play("Close Door L", 0, 0.0f);
            }

        }
    }
}
