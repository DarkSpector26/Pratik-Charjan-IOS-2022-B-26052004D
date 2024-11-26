using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D Rb;

    public float StartSpeed = 1.0f;
    private Score Score;

    void Start()
    {

        Score = FindObjectOfType<Score>();

        bool isRight = Random.value >= 0.5;

        float xVelocity = -1.0f;

        if (isRight == true)
        {
            xVelocity = 1.0f;
        }

        float yVelocity = Random.Range(-1, 1);
        if (yVelocity == 0) yVelocity = 1.0f;

        Rb.velocity = new Vector2 (xVelocity * StartSpeed, yVelocity * StartSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            SoundManager.Instance.PlaySound3D("Ball", transform.position);
            Score.Player2Score();
            Debug.Log("oooo");

        }


        else if (collision.gameObject.CompareTag("RightWall"))
        {
            SoundManager.Instance.PlaySound3D("Ball", transform.position);
            Score.Player1Score();
            Debug.Log("Touched");

        }

        
    }

}
