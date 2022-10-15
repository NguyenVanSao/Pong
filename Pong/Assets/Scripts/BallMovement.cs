using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float startSpeed;
    [SerializeField] float extraSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float hitCounter;

    public bool player1Start = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        _rb.velocity = new Vector2(0, 0);
        this.transform.position = new Vector2(0, 0);

    }

    public IEnumerator Launch()
    {
        RestartBall();  
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (player1Start == true)
        {
            moveBall(new Vector2(-1, 0));
        }
        else
        {
            moveBall(new Vector2(1, 0));
        }
    }

    public void moveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        Debug.LogError(ballSpeed);

        _rb.velocity = direction * ballSpeed * Time.deltaTime;
    }

    public void IncreaseHitCounter()
    {
        if ((startSpeed + hitCounter * extraSpeed) < maxSpeed) {
            hitCounter++;
        }
    }
}
