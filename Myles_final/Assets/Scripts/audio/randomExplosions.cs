using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomExplosions : MonoBehaviour
{
    AudioSource explosion;
    int time;  
    
       
    // Start is called before the first frame update
    void Start()
    {   
        int randomNum = Random.Range(1, 30);
        time = randomNum;
        explosion = GetComponent<AudioSource>();
        InvokeRepeating("PlayAudio", time, 30f);
    }
    void PlayAudio()
    {
        GetComponent<AudioSource>().volume = Random.Range(0.9f, 1.5f);
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.3f);
        explosion.Play();
    }

}
