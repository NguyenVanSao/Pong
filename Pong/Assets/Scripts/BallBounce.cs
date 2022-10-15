using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] GameObject hitSFX;

    [SerializeField] BallMovement ballMovement;
    [SerializeField] ScoreManager scoreManager;

    public void Bounce(Collision2D collision)
    {
        Vector3 ballPos = this.transform.position;
        Vector3 racketPos = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float PosX = -1;
        if (collision.gameObject.name == "Player 1")
        {
            PosX = 1;
        }
        if (collision.gameObject.name == "Player 2")
        {
            PosX = -1;
        }

        float PosY = (ballPos.y - racketPos.y) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.moveBall(new Vector2(PosX, PosY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
        }

        if(collision.gameObject.name == "Left Border")
        {
            scoreManager.player2Goal();
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }

        if (collision.gameObject.name == "Right Border")
        {
            scoreManager.player1Goal();
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }

        Instantiate(hitSFX, this.transform.position, Quaternion.identity);
    }
}
