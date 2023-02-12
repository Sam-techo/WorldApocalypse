using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitpoints = 100f;

    public void TakeDamage(float damage)
    {
        hitpoints = hitpoints - damage;
        Debug.Log("hit enemy");

        if (hitpoints <= 0)
        {
            transform.GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
