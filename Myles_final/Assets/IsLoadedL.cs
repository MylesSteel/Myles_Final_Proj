using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLoadedL : MonoBehaviour
{
    [SerializeField]
    public bool isLoaded = false;
    [SerializeField]
    public Animator door = null;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cannon ball load"))
        {
            isLoaded = true;
            door.Play("Close Door L", 0, 0.0f);
            
        }
    }

}