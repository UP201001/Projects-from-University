using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

	public bool isFlipped = false;

	
    public Animator animator;
    public int maxHP = 100;
    int currentHP;
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage){
        currentHP -= damage;

        Debug.Log(currentHP);

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
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
