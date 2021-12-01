using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToShip : MonoBehaviour
{
    [SerializeField]
    GameObject link;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = link.transform.position;

    }
}
