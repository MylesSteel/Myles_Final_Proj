using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class customUnityEventRequirment : MonoBehaviour
{
    [SerializeField]
    private UnityEvent trigger;  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger.Invoke();                                        // on trigger enter the unity events system will invoke its populated field. 
        }
        
    }
}
