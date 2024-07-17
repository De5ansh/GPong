using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float spd;
    private Vector2 racketDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Vertical");
        racketDirection = new Vector2(0, direction).normalized;
    }

    void FixedUpdate() {
        rb.velocity = racketDirection * spd;

    }
}
