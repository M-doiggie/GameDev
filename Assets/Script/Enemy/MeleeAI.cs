using System;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    Animator animator;

    private float health;

    public LayerMask whatIsGround, whatIsPlayer;

    private float attackCooldown;
    private float timeBetweenAttacks;
    bool alreadyAttacked;

    private float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private int damage;


    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        health = 100;
        damage = 4;
        attackRange = 3;
        sightRange = 20;
        timeBetweenAttacks = 60;
        animator = GetComponent<Animator>();
        alreadyAttacked = false;
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (playerInSightRange && !playerInAttackRange) { chase(); }
        if (playerInAttackRange) { attack(); }
    }

    private void attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (alreadyAttacked == false)
        {
            //Add Attacking Feature here
            player.gameObject.GetComponent<PlayerInteractionController>().takeDamage(damage);
            animator.SetBool("canPunch", false);
            alreadyAttacked = true;
            attackCooldown = timeBetweenAttacks;
        }
        else {
            attackCooldown -= 1;
            if (attackCooldown <= 0) {
                //animator.SetBool("canPunch", true);
                alreadyAttacked = false;
            }
        }
    }

    private void chase()
    {
        agent.SetDestination(player.position);
    }

    public void TakeDamage(int damage) {

        health -= damage;

        if (health <= 0) {
            Invoke(nameof(DestroyEnemy), 2f);
        }
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }
   
}
