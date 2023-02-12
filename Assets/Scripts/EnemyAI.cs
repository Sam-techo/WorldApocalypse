using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] float chaseRange = 8f;
    [SerializeField] float turnSpeed = 5f;
    EnemyHealth enemyHealth;   

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Transform player;
    
    bool isProvoked = false;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        player = FindAnyObjectByType<PlayerHealth>().transform;
    }

    
    void Update()
    {
        if (enemyHealth.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
        }

        distanceToTarget = Vector3.Distance(player.position, transform.position);

        // if in range provoke true, engage target
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
      
        
    }

    void onDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        //if distance more than stopping distance keep on chasing
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();

        }
        // if distance less than stopping ditance attack player
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    // pursue player
    void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(player.position);
    }

    // attack player
    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        Debug.Log("Exterminate");
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        
    }
}
