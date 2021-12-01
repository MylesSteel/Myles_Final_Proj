using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRight : MonoBehaviour, TurnInterface
{
    [SerializeField]
    Transform shipTransform;
    [SerializeField]
    float speed = 5f;
  private void Awake()
    {
        shipTransform = GetComponent <Transform>();
        
    }
    public void WheelTurnedLeft(float dialvalue)
    {
        shipTransform.position += Time.deltaTime * speed * -transform.right;

    }

    public void WheelTurnedRight(float dialvalue)
    {
        shipTransform.position += Time.deltaTime * speed * transform.right;
    }

    // Start is called before the first frame update

  

}
