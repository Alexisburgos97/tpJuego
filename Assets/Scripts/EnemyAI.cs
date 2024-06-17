using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    public float AttackRate = 1f; // Time between attacks
    private float NextAttackTime = 0f;
    public float Velocity; // Desired movement speed

    public Transform Goal; // Target for the enemy to follow
    [SerializeField] private NavMeshAgent AI; // NavMeshAgent component to handle pathfinding
    [SerializeField] private Animator Animator; // Animator component to handle animations

    [SerializeField] public string WalkSpeedParam = "WalkSpeedEnemy";
    
    private List<string> attackParams = new List<string>();
    private int currentAttackIndex = 0;

    public bool isFinalEnemy = false;
    
    private void Start()
    {
        // Initialize the NavMeshAgent properties
        if (AI == null)
        {
            AI = GetComponent<NavMeshAgent>();
            if (AI == null)
            {
                Debug.LogError("NavMeshAgent component is missing from the enemy GameObject.");
            }
        }

        AI.speed = Velocity;
        AI.SetDestination(Goal.position);

        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
            if (Animator == null)
            {
                Debug.LogError("Animator component is missing from the enemy GameObject.");
            }
        }
        
        if (isFinalEnemy)
        {
            attackParams.Add("AttackEnemyFinal");
            attackParams.Add("AttackEnemyFinal2");
        }
        else
        {
            attackParams.Add("AttackEnemy");
        }
        
    }

    private void Update()
    {
        if (AI == null || Animator == null) return;

        // Update the NavMeshAgent's speed and destination
        AI.speed = Velocity;
        AI.SetDestination(Goal.position);

        // Calculate the current speed of the NavMeshAgent
        float currentSpeed = AI.velocity.magnitude;

        // Update the WalkSpeed parameter in the Animator if the animator is present
        Animator.SetFloat(WalkSpeedParam, currentSpeed);
        
        // Rotate the enemy to face the goal
        Vector3 direction = (Goal.position - transform.position).normalized;
        direction.y = 0; // Keep the enemy on the same plane
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * AI.angularSpeed);

        // Check if the NavMeshAgent is close to the goal
        if (Vector3.Distance(transform.position, Goal.position) < AI.stoppingDistance)
        {
            if (Time.time >= NextAttackTime)
            {
                // Trigger the attack animation
                // Animator.SetTrigger(AttackTriggerParam);
                
                if (attackParams.Count > 0)
                {
                    Animator.SetTrigger(attackParams[currentAttackIndex]);
                    
                    currentAttackIndex = (currentAttackIndex + 1) % attackParams.Count;
                }
                
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
    }
    
}