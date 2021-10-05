using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal;   
    float vertical;
    bool slide;
    float acceleration = 30f;
    float deceleration = 0.80f;
    float maxSpeed = 10f;
    float speed = 0f;
    float velocityStopValue = 0.3f;

    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetKey("left shift")) {
            slide = true;
        }

        if(slide) {
            horizontal = 0;
            vertical = 0;
            deceleration = 0.95f;
            velocityStopValue = 0.2f;
            slide = false;
        }

        if(speed < maxSpeed) {
            speed += acceleration * Time.deltaTime;
        }

        if(horizontal == 0 && vertical == 0) {
            decelerate();
            velocityStopValue = 0.3f;
            deceleration = 0.80f;
            speed = 0f;
        } else {
            if (horizontal != 0 && vertical != 0) {
                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        

        
    }

    private void decelerate() {
        if (rb.velocity.magnitude > new Vector2(velocityStopValue, velocityStopValue).magnitude) {
                rb.velocity = rb.velocity * deceleration;
            } else {
                rb.velocity = new Vector2(0, 0);
            }
    }
}
