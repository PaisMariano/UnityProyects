using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{

    private CharacterAnimations enemyAnim;
    private NavMeshAgent navAgent;

    private Transform playerTarget;

    public float moveSpeed = 3.5f;
    public float attackDistance = 1f;
    public float chasePlayerAfterAttackDistance = 1f;

    private float waitBeforeAttackTime = 3f;
    private float attackTimer;

    private EnemyState enemyState;

    void Awake()
    {
        enemyAnim = GetComponent<CharacterAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;

    }

    void Start()
    {
        enemyState = EnemyState.CHASE;
        attackTimer = waitBeforeAttackTime;
    }

    private void Update()
    {   
        if(enemyState == EnemyState.CHASE)
        {
            ChasePlayer();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            AttackPlayer();
        }    
    }
    void ChasePlayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = moveSpeed;

        if(navAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnim.Walk(false);
        }
        else
        {
            enemyAnim.Walk(true);
        }
        if(Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyState = EnemyState.ATTACK; 
        }

    }
    void AttackPlayer()
    {

    }
}
