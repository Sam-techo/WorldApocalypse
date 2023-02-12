using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera fpsCamera;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomOutFOV = 40;
    [SerializeField] float zoomInFOV = 20;
    [SerializeField] float zoomOutSenstivity = 1.2f;
    [SerializeField] float zoomInSenstivity = 0.5f;

    bool isZoomed = false;

    void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomed == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
        
    }

    private void ZoomOut()
    {
        isZoomed = false;
        fpsCamera.m_Lens.FieldOfView = zoomOutFOV;
        firstPersonController.RotationSpeed = zoomOutSenstivity;
    }

    private void ZoomIn()
    {
        isZoomed = true;
        fpsCamera.m_Lens.FieldOfView = zoomInFOV;
        firstPersonController.RotationSpeed = zoomInSenstivity;
    }
}
