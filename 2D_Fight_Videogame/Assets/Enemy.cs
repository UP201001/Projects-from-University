using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHP = 100;
    int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage){
        currentHP -= damage;

        animator.SetTrigger("Hurt");
        
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Die(){
        Debug.Log("Enemy died");
        animator.SetBool("isDie", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
