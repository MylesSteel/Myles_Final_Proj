using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsLoadedL : MonoBehaviour // this trigger is used to lock the cannon doors.
                                       // If the cannon bal is in the collider, door close animation and sound plays.
                                       // doors will not open until chamber is cleared.
{
    [SerializeField]
    public bool isLoaded = false;
    [SerializeField]
    public Animator door = null;
    public UnityEvent sound;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cannon ball load"))
        {
            sound.Invoke();
            isLoaded = true;
            door.Play("door left close", 0, 0.3f);
            
        }
    }

}