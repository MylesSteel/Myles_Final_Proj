using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour           //plays foots step audio source when charecter controller is in contact with ground and moving.
                                                 //Sound is played at random pitch and volume for varied effect.
{
        CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();  
    }
    void Update()
    {
       
        if (cc.isGrounded == true && cc.velocity.magnitude > 0.1f && GetComponent<AudioSource>().isPlaying == false)      
        {
            GetComponent<AudioSource>().volume = Random.Range(0.9f, 1);
            GetComponent<AudioSource>().pitch = Random.Range(1f, 1.3f);
            GetComponent<AudioSource>().Play();
            
        }
        
    }
}
