using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsLoaded : MonoBehaviour              // this trigger is used to lock the cannon doors.
                                                   // If the cannon bal is in the collider, door close animation and sound plays.
                                                   // doors will not open until chamber is cleared.
{
    [SerializeField]
    public bool isLoaded = false;
    [SerializeField]
    public Animator door = null;
    [SerializeField] AudioSource cannonLoaded;
    public UnityEvent sound;
    public void OnTriggerEnter(Collider other)
    {
        if  (other.CompareTag("cannon ball load"))            //All cannon balls have this tag.
        {
            isLoaded = true;
            door.Play("door right close", 0, 0.0f);
            sound.Invoke();                                       //used so it can trigger multiple sound sources
        }
    }

}
