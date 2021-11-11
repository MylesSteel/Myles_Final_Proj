using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour                              //applied to bullet prefab for gun
{
    Rigidbody rB;
    [SerializeField]
    float speed = 0.01f;                                 //speed slider
    [SerializeField]
    float lifeSpan = 1.5f;                               //lifespan slider
    Transform gun;

   // [SerializeField]
   // Transform tF;

    void Start()
    {
        gun = GameObject.Find("Gun").transform;
        rB = GetComponent<Rigidbody>();                                                 
        rB.AddForce(gun.forward * (speed), ForceMode.Impulse);            //applies forward force 
        //rB.AddForce(Vector3.up, ForceMode.Impulse);
     
    }

     //Update is called once per frame
    void Update()
    {
        if (lifeSpan >= 0)
        {
            lifeSpan -= Time.deltaTime;                       //counts/checks lifespan left
        }
        else
        {
            Destroy(gameObject);                      //destroys game object after lifespan 
        }
    }
}
