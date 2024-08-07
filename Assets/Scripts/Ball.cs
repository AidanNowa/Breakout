using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float acceleration = 1.1f;
    public float maxStartY = 4f;
    private float startX = 0f;


    private void ResetBall() {
        //ResetBallPosition();
        InitialPush();
    }

    private void Start() {
        InitialPush();
    }

    /*private void ResetBallPosition() {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }*/
    private void InitialPush() {
        //randomly send ball left or right on scale from Random.range(0,1) shorthand
        Vector2 dir = Vector2.up;
        dir.x = Random.Range(-maxInitialAngle,maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }

/*  Modify for when ball is missed
    private void OnTriggerEnter2D(Collider2D collision) {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone) {
            GameManager.instance.OnscoreZoneReached(scoreZone.id);
        }
        
    }
*/
    private void OnCollisionEnter2D(Collision2D collision) {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle) {
            //Debug.Log("Hit Paddle");
            rb2d.velocity *= acceleration;
        }
    }
}
