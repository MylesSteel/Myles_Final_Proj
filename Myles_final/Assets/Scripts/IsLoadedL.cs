using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsLoadedL : MonoBehaviour
{
    [SerializeField]
    public bool isLoaded = false;
    [SerializeField]
    public Animator door = null;
    [SerializeField] AudioSource loadCannon;
    public UnityEvent sound;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cannon ball load"))
        {
            sound.Invoke();
            isLoaded = true;
            door.Play("Close Door L", 0, 0.0f);
            
        }
    }

}