using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageDisplayCanvas;
    [SerializeField] float impactTimer = 0.3f;

    void Start()
    {
        damageDisplayCanvas.enabled = false;
        
    }

    public void DamageDisplay()
    {
        StartCoroutine(BloodSplatter());
    }

    IEnumerator BloodSplatter()
    {
        damageDisplayCanvas.enabled = true;
        yield return new WaitForSeconds(impactTimer);
        damageDisplayCanvas.enabled = false;
    }
}
