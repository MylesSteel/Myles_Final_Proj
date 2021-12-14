using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomExplosions : MonoBehaviour
{
    AudioSource explosion;
    int time;  
    void Start()
    {   
        int randomNum = Random.Range(1, 30);              //random num gen used to start audio sources at different times in its 30 second interval. 
        time = randomNum;
        explosion = GetComponent<AudioSource>();
        InvokeRepeating("PlayAudio", time, 30f);         //used to keep Play audio function repeating ever 30 seconds.
    }
    void PlayAudio()                                   //randomize pitch and volume for variety.
    {
        GetComponent<AudioSource>().volume = Random.Range(0.9f, 1.5f);
        GetComponent<AudioSource>().pitch = Random.Range(0.4f, 0.6f);
        explosion.Play();
    }

}
