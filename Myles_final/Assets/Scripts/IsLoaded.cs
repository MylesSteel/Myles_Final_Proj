using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsLoaded : MonoBehaviour
{
    [SerializeField]
    public bool isLoaded = false;
    [SerializeField]
    public Animator door = null;
    [SerializeField] AudioSource cannonLoaded;
    public UnityEvent sound;
    public void OnTriggerEnter(Collider other)
    {
        if  (other.CompareTag("cannon ball load"))
        {
            isLoaded = true;
            door.Play("Close Door", 0, 0.0f);
            sound.Invoke(); 
        }
    }

}
