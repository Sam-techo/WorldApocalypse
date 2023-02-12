using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        
    }

    void onDamageTaken()
    {
        Debug.Log("I'm Stunned");
    }
    void AttackHitEvent()
    {
        if (transform == null) return;
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().DamageDisplay();
    }
}  
