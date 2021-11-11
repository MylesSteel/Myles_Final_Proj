using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.InputSystem;
using System;

public class VignetteScript : MonoBehaviour
{
    [SerializeField]
    float intensity = 0.75f;                                      //on screen vingette intesity
    [SerializeField]
    float duration = 0.5f;                                        //duration off effect after release
    [SerializeField]
    private Volume volume;
    Vignette vignette;
    [SerializeField]
    InputActionReference continousMove;

    private void Awake()
    {
        continousMove.action.performed += FadeIn;              //applies function when joy stick is pressed
        continousMove.action.canceled += FadeOut;              //applies function when joy stick is released

        if (volume.profile.TryGet(out Vignette vignette))
            this.vignette = vignette;
    }

    private void FadeOut(InputAction.CallbackContext obj)
    {
        StartCoroutine(Fade(0, intensity));                   //called if joystick value is 0
    }

    private void FadeIn(InputAction.CallbackContext obj)
    {
        if (obj.ReadValue<Vector2>() != Vector2.zero)             //checkes joystick value and applies if statment if not 0
        {
            StartCoroutine(Fade(intensity, 0));                    

        }
    }
    IEnumerator Fade(float startValue, float endValue)
    {
        float elapsedTime = 0.0f;
        float blend = elapsedTime / duration;
        float intensity = Mathf.Lerp(startValue, endValue, blend);               //calculates vignette inesity based off two variables that determin how long in use
        ApplyValue(intensity);
        yield return null;
    }

    private void ApplyValue(float value)
    {
        vignette.intensity.Override(value);                                    //applies intesity float from above and overrides value.
    }
}
