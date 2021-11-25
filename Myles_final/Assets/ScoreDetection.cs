using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreDetection : MonoBehaviour
{
    [SerializeField]
    private UnityEvent timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreDetection"))
        {
            timer.Invoke();
        }
    }
}
