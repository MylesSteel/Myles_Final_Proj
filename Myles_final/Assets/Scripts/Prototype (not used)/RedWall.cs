using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall : MonoBehaviour                    //this script sets a game object poplated in inspector to active. 
{
    [SerializeField] 
    private GameObject redWallCube;

    public void ActivateWall()
    {
        redWallCube.SetActive(true);                    //game object being set active. 
    }
}
