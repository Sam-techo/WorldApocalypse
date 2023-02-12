using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1.0f;
    [SerializeField] float minAngle = 40f;

    Light flashLight;
    void Start()
    {
        flashLight= GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
        
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        flashLight.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float restoreIntensity)
    {
        flashLight.intensity += restoreIntensity;
    }

    private void DecreaseLightIntensity()
    {
        flashLight.intensity -= lightDecay * Time.deltaTime; 
    }
        
    private void DecreaseLightAngle()
    {
        if (flashLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            flashLight.spotAngle -= angleDecay * Time.deltaTime;
        }
        
    }
}
