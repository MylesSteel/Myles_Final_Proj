using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall : MonoBehaviour
{
    [SerializeField] 
    private GameObject redWallCube;

    public void ActivateWall()
    {
        redWallCube.SetActive(true);
    }
}
