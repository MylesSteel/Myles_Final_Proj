using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// the object is enabled by the hands physics, the base object is kinetic so the push obj doesnt move it. both objects are in emptys so that the objects are at location 0. needed info for start position vector3.
public class EventButton : MonoBehaviour
{
   
    [SerializeField]
    private float threshold = 0.1f;                   //percentage of the button pressed to active on pressed. can be scaled in unity. its a defined line to compare to the joint limit location.
    [SerializeField]
    private float deadZone = 0.025f;                  //an extra float used to prevent the function from having a rapid on off effect. 

    private bool isPressed;                           //used to track if button has been pressed so it doesnt update each frame.
    private Vector3 startPos;                         //a position used to messure how far the button has moved from this point.
    private ConfigurableJoint joint;                  //joint used for button object, this refrences is for the liniar limit used on the joint.
    
    public UnityEvent onPressed, onRealeased;
   
    
   
    void Start()
    {
        startPos = transform.localPosition;                    //.localposition is used to find the parent transform. that was it is scaled relitive to its parent.
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)           // check if ispressed has been toggled, get value method for locations and joint limit value, check threshold value and pressed if >=1.  
            Pressed();
        if (isPressed && GetValue() - threshold <= 0)            //low end of threshold
            Released();
    }
    //the reason the button doesnt compare the difference of the value and uses percentege instead is so it can be used for many different purposes. the get value function messures -1,0,1 of the 
    private void Pressed()
    {
        isPressed = true;                          //button has been pressed
        onPressed.Invoke();                        //onPress button begin the populated field 
        Debug.Log("pressed");
    }

    private void Released()                               //same as pressed but at low end of threshold.
    {
        isPressed = false;
        onRealeased.Invoke();
        Debug.Log("released");
    }
    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;                          // value equals the distance between the start postion and the localposition and divides it by the liniar limit to get a percentage of the limit.

        if (Mathf.Abs(value) < deadZone)                             //returns the absolute value of value, if its less then deadzone (0.025f) then it is 0. This is the dead space messurement used to prevent rapid fire of the button. if its is the space it = 0.
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);                          //clamps the float values with a min and max, returns the given value if in the range. if it is bellow or above it hits the limits. This is used to prevent weird numbers in the threshold messurement of pressed.
    }
}
