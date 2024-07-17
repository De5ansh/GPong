using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float spd;
    public float extraSpd;
    public float maxSpd;

    private int hitCounter = 0;
    private Rigidbody2D rb;
    public bool playerStart = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(Launch());
    }

    public void Restart() {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }

    public IEnumerator Launch() {

        
        Restart();
        int hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (playerStart == true) {
            MoveBall(new Vector2(-1,0));
        } else {
            MoveBall(new Vector2(1,0));
        }
        
    }

    public void MoveBall(Vector2 direction) {
        direction = direction.normalized;
        float ballSpeed = spd + extraSpd * hitCounter;
        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHit() {
        if (spd + hitCounter * extraSpd < maxSpd) {
            hitCounter++;
        }
    }

    // Update is called once per frame
}
