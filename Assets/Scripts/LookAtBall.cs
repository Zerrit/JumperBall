using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBall : MonoBehaviour
{
    private Transform ball;
    private float speed = 6;

    private void Start()
    {
        ball = GameObject.Find("Ball").transform;
    }

    private void LateUpdate()
    {
        if (ball.position.y - transform.position.y > 5) MoveToBall();

        if (ball.transform.position.y + .3f < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime , transform.position.z);
        }

        if (ball.transform.position.y + 1f > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
    }

    private void MoveToBall()
    {
        transform.position = new Vector3(transform.position.x, ball.position.y, transform.position.z);
    }
}
