using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruiserAI : MonoBehaviour
{
    [Header("Variables")]
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    private bool isCharging;
    public float chargeSpeed;
    public float chargeDuration;
    public float chargeCooldown;

    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !isCharging) patrolling();
        if (playerInSightRange && !playerInAttackRange && !isCharging) chasePlayer();
        if (playerInSightRange && playerInAttackRange && !isCharging) StartCoroutine(chargeAttack());
    }

    private void patrolling()
    {
        if (!walkPointSet) searchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void searchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void chasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private IEnumerator chargeAttack()
    {
        isCharging = true;
        agent.isStopped = true;
        transform.LookAt(player);
        yield return new WaitForSeconds(chargeCooldown);
        float timer = 0f;

        while (timer < chargeDuration)
        {
            Vector3 direction = player.position - transform.position;
            agent.Move(direction.normalized * chargeSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        isCharging = false;
        agent.isStopped = false;
    }
}
