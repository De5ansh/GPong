using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hit;
    public BallMovement move;
    public ScoreManager score;
    private Rigidbody2D rb;
    private bool isPlayer1Goal;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Bounce(Collision2D collision) {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;

        if (collision.gameObject.name == "Player1") {
            positionX = 1;
        } else {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        move.IncreaseHit();
        move.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2") {
        Instantiate(hit, transform.position, transform.rotation);
        Bounce(collision);
    }

    if (collision.gameObject.name == "Right") {
        rb.velocity = new Vector2(0,0);
        isPlayer1Goal = true;
        StartCoroutine(WaitAndRestart(true));
    } else if (collision.gameObject.name == "Left") {
        rb.velocity = new Vector2(0,0);
        isPlayer1Goal = false;
        StartCoroutine(WaitAndRestart(false));
    }

    
}

public IEnumerator WaitAndRestart(bool isPlayer1Goal) {
    yield return new WaitForSeconds(0.5f);
    if (isPlayer1Goal) {
        score.Player1Goal();
        move.playerStart = false; 
    } else {
        score.Player2Goal();
        move.playerStart = true;
    }

}


    
}
