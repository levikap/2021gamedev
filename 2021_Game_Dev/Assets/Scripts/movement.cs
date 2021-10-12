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
    float dashMultiplier = 100.0f;

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

        if(Input.GetKeyDown("space"))
        {
            Debug.Log("dashing");
            dash();
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

    private void dash()
    {
        float dash_x;
        float dash_y;
        if(horizontal == 0 && vertical == 0)
        {
            dash_x = 0f;
            dash_y = dashMultiplier;
        } else
        {
            dash_x = horizontal * dashMultiplier;
            dash_y = vertical * dashMultiplier;
        }

        float step = dashMultiplier * Time.deltaTime;
        Vector3 target = new Vector3(transform.position.x + dash_x, transform.position.y + dash_y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
