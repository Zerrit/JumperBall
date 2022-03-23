using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBall : MonoBehaviour
{
    private GameObject ball;
    [SerializeField] private float MinBallPos;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        MinBallPos = ball.transform.position.y;
    }

    private void LateUpdate()
    {
        if (ball.transform.position.y < MinBallPos)
        {
            MinBallPos = ball.transform.position.y;
        }

        if (MinBallPos + 0.9f < transform.position.y)
        {
            Vector3 pos = transform.position;
            pos.y = transform.position.y - 0.09f;
            transform.position = pos;
        }

        if (ball.transform.position.y > transform.position.y + 0.2f)
        {
            MinBallPos = ball.transform.position.y;
            Vector3 pos = transform.position;
            pos.y = transform.position.y + 1f;
            transform.position = pos;
        }
    }
}
