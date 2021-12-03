using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class FireCannon : MonoBehaviour
{
    
    private XRGrabInteractable grabInteractable; //refrence
    [SerializeField]
    GameObject bulletPrefab;                     //game object for bullet
    [SerializeField]
    Transform spawnPoint;                        //spawn location for bullet at end of gun
    // public ParticleSystem muzzleFlash;
   
    public void ShootBullet()
    {
        Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        
        // muzzleFlash.Play();    
    }
}
