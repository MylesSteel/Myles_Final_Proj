using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] public Animator door = null;
    [SerializeField] AudioSource doorSlide;
    [SerializeField] IsLoaded myLoaded;

   
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!myLoaded.isLoaded)
            {
                door.Play("door right open", 0, 0.0f);
                doorSlide.Play();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!myLoaded.isLoaded)
            {
                door.Play("door right close", 0, 0.0f);
                doorSlide.Play();
            }

        }
    }
}
