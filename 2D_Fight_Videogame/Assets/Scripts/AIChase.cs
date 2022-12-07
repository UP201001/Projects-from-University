using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public float distanceBetween = 4f;
    private bool m_FacingRight = true; 
    private float horizontal = 0f;
    
    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            if(horizontal > 0.0f && !m_FacingRight) Flip();
            else if (horizontal < 0.0f && m_FacingRight) Flip();

            float currentAngle = angle;

            if (currentAngle >= 180f)
            {
                currentAngle = 0f;
            }
            else currentAngle = 0f;

            //Debug.Log(currentAngle);

            transform.rotation = Quaternion.Euler(Vector3.forward * (currentAngle));
        }
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
