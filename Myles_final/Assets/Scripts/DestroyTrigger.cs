using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour         //used with animation. Animation moves collider onto ball when cannon is fired. If ball is in trigger it is destroyed. 
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("cannon ball load"))
        {
            Destroy(other.gameObject);
        }
    }
}
