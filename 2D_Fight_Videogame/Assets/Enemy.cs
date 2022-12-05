using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rigidbody2D;
    public Transform player;
    private bool lookingRight = true;
    private float maxHP;
    private HealthBar healthBar;

    private void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        healthBar.
    }
    
    public void TakeDamage(int damage){
        currentHP -= damage;

        animator.SetTrigger("Hurt");
        
        if (currentHP <= 0)
        {
            Die();
        }
    }
}
