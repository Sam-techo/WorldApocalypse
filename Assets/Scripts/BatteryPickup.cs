using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restorAngle = 70f;
    [SerializeField] float addIntensity = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restorAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
