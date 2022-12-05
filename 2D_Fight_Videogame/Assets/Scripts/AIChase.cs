using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    public float distanceBetween = 4f;
    
    
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            float currentAngle = angle;

            if (currentAngle >= 180f)
            {
                currentAngle = 0f;
            }
            else currentAngle = 0f;

            Debug.Log(currentAngle);

            transform.rotation = Quaternion.Euler(Vector3.forward * (currentAngle));
        }
    }
}
