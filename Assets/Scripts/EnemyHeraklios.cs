using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHeraklios : MonoBehaviour
{
    
    public float HealthEnemy = 100;
    public float HealthMax = 100;
    public float AttackDamage = 5f;

    private Rigidbody Rb;
    private bool isDead = false;
    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        
        // Congelar la rotación en los ejes X e Y para mantener al personaje erguido
        Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
    }

    private void Update()
    {
        if (HealthEnemy > HealthMax)
        {
            HealthEnemy = HealthMax;
        }
    }

    void FixedUpdate()
    {
        // Forzar al jugador a mantenerse erguido
        Vector3 uprightRotation = new Vector3(0, transform.eulerAngles.y, 0);
        Rb.MoveRotation(Quaternion.Euler(uprightRotation));
    }
    
    // Verificar si el personaje está en el suelo
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }
    
    public void TakesDamage(float damage)
    {
        HealthEnemy -= damage;
        
        if (HealthEnemy <= 0)
        {
            Die();
        }
    }
    
    public void DealDamageToPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.0f);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                CodHealth playerHealth = hitCollider.GetComponent<CodHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakesDamage(AttackDamage);
                }
            }
        }
    }
    
    private void Die()
    {
        
        if (isDead) return;
        
        isDead = true;
        
        Destroy(gameObject);
    }
    
    public float GetHealthEnemy()
    {
        return HealthEnemy;
    }
    
    public bool IsDead()
    {
        return isDead;
    }

}
