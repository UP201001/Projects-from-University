using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    
    [Range(0, 5f)] public float attackRate = 2f;
    [Range(0, 5f)] public float attackRange;
    [Range(0, 5f)] public float nextAttackTime = 0f;
    [Range(0, 30)] public int attackDamage;

    private HealthSystem healthSystem;
    public int HP;

    void Start()
    {
        healthSystem = new HealthSystem(HP);
        Debug.Log("Player Health: " + healthSystem.GetHealth());

    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        healthSystem.Damage(damage);

        Debug.Log(healthSystem.GetHealth());

        animator.SetTrigger("Hurt");

        if (healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("isDie", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
