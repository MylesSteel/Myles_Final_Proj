using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 

public class MoveShip : MonoBehaviour
{   [SerializeField]
    Rigidbody shipRbController;
    [SerializeField]
    float speed = 5f;
    [SerializeField] Transform wheel;  //gameobject that is rotated for values
    [SerializeField] private int snapRotationAmount = 10;   //increments the dummy hands will move at
    [SerializeField] private GameObject rightHandModel;     //dummy hand that attaches to wheel.    
    [SerializeField] private GameObject leftHandModel;
    [SerializeField] bool useDummyHands;
    [SerializeField] private float angleTolerance;    //hand rotation value for wheel
    [SerializeField] AudioSource turnWheel;

    private XRBaseInteractor interactor;
    private float startAngle;     //start angle when grabbed 
    private bool requireStartAngle = true;  
    private bool shouldGetHandRotation = false;    
    public float GetInteractorRotation() => interactor.GetComponent<Transform>().eulerAngles.y; 
    private XRGrabInteractable grabInteractor => GetComponent <XRGrabInteractable>();    //xr toolkit grab component. find rotation value.

    private void OnEnable()          //when using select trigger to grab, enable GrabbedBy/GrabEnd functions.  (listens for grab interactable)
    {
        grabInteractor.selectEntered.AddListener(GrabbedBy);
        grabInteractor.selectExited.AddListener(GrabEnd);
    }

    private void OnDisable()        //on release do same as above
    {
        grabInteractor.selectEntered.RemoveListener(GrabbedBy);
        grabInteractor.selectExited.RemoveListener(GrabEnd);
    }

    private void GrabEnd(SelectExitEventArgs arg0)
    {
        shouldGetHandRotation = false;                     //do not get value to turn ship
        requireStartAngle = true;                          
        HandModelVisibility(false);    
    }

    private void GrabbedBy(SelectEnterEventArgs arg0)                             //grabbing the wheel
    {
        interactor = GetComponent<XRGrabInteractable>().selectingInteractor;                     // interactor that is being used with wheel object.     when select is used do the following
        interactor.GetComponent<XRDirectInteractor>().hideControllerOnSelect = true;           //hide hands in XR rig
        shouldGetHandRotation = true;                                                          //calculate hand rotation value
        startAngle = 0f;                                                                        //start angle is now 0 again
        HandModelVisibility(true);                                                                 //use dummy hand snap
    }

    private void HandModelVisibility(bool visibilityState)
    {
        if (!useDummyHands)
            return;

        if (interactor.CompareTag("right hand"))
            rightHandModel.SetActive(visibilityState);

        if (interactor.CompareTag("left hand"))
            leftHandModel.SetActive(visibilityState);
    }

    private void Update()       //in update so it can calculate value of rotation on each frame when shouldGetHandRotation bool is = true.
    { 
        RotateWheelLeft();         //trying to call the functions on every frame to get constant feed back.
        RotateWheelRight();
        if (shouldGetHandRotation)
        {
            var rotationAngle = GetInteractorRotation();  //gets the current rotation angle of controller
            GetRotationDistance(rotationAngle);
        }
       
    }
    
    private void GetRotationDistance(float currentAngle)
    {
        if (!requireStartAngle)
        {
            var angleDifference = Mathf.Abs(startAngle - currentAngle);              //angle difference == the difference between the start angle of the object and the rotation of the hand

            if (angleDifference > angleTolerance)                                   //angle difference value being greater then the tolerance set in inspector will result in the wheel rotation
            {
                if (angleDifference > 270f)
                {
                float angleCheck;

                    if (startAngle < currentAngle)           //used to tell if the wheel has gone right or left from the starting angle. if less than start angle it is turning + or clockwise and therfor right.
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTolerance)
                            return;

                        else
                        {
                            RotateWheelRight();
                            startAngle = currentAngle;
                        }
                    }
                    else if (startAngle > currentAngle)     // rotation is - or counterclockwise so rotation is left.
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTolerance)
                            return;
                        else
                        {
                            RotateWheelLeft();
                            startAngle = currentAngle;
                        }
                    }
                }
                else
                {
                    if (startAngle < currentAngle)
                    {
                        RotateWheelLeft();
                        startAngle = currentAngle;
                    }
                    else if (startAngle > currentAngle)
                    {
                        RotateWheelRight();
                        startAngle = currentAngle;
                    }
                }
                
            }
           
        }
        else
        {
             requireStartAngle = false;
             startAngle = currentAngle;
        }
       
    } 
    private float CheckAngle(float currentAngle, float startAngle) => (360f - currentAngle) + startAngle;

  

    private void RotateWheelRight()
    {
        wheel.localEulerAngles = new Vector3(wheel.localEulerAngles.x,
                                             wheel.localEulerAngles.y,
                                             wheel.localEulerAngles.z + snapRotationAmount);
        if (TryGetComponent<TurnInterface>(out TurnInterface dial))
            dial.WheelTurnedRight(wheel.localEulerAngles.y);
        
        shipRbController.AddForce(Vector3.right * (speed), ForceMode.Force);
        turnWheel.Play();
    }

   private void RotateWheelLeft()
   {
        wheel.localEulerAngles = new Vector3(wheel.localEulerAngles.x,
                                             wheel.localEulerAngles.y,
                                             wheel.localEulerAngles.z - snapRotationAmount);
        if (TryGetComponent<TurnInterface>(out TurnInterface dial))
            dial.WheelTurnedLeft(wheel.localEulerAngles.y);
        
        shipRbController.AddForce(Vector3.left * (speed), ForceMode.Force);
        turnWheel.Play();
    }
}
