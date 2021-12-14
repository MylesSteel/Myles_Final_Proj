using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour                  //checks to see if cannon shoots are loaded. If not the open and close animations and sounds will play on enter and exit. 
{
    [SerializeField] public Animator door = null;          
    [SerializeField] AudioSource doorSlide;
    [SerializeField] IsLoaded myLoaded;          //reference to is loaded script.

   
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
