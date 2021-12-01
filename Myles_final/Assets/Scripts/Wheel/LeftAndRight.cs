using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRight : MonoBehaviour, TurnInterface
{
    [SerializeField]
    Rigidbody shipRbController;
    [SerializeField]
    float speed = 5f;
   
    public void WheelTurnedLeft(float dialvalue)
    {
        shipRbController.AddForce(Vector3.left * (speed), ForceMode.Force);

    }

    public void WheelTurnedRight(float dialvalue)
    {
        shipRbController.AddForce(Vector3.right * (speed), ForceMode.Force);
        
    }

  



}
