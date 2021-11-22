using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 



public class SwitcHands : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    [SerializeField]
    Transform leftHandAttached;
    [SerializeField]
    Transform rightHandAttached;
    [SerializeField]
    GameObject leftHandInteractor;
    [SerializeField]
    GameObject rightHandInteractor;
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void SwapHands()
    {
        if (grabInteractable.selectingInteractor.name == leftHandInteractor.name)
        {
            grabInteractable.attachTransform = leftHandAttached;
        }
        if (grabInteractable.selectingInteractor.name == rightHandAttached.name)
        {
            grabInteractable.attachTransform = rightHandAttached;
        }
    }
}
