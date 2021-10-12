using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    float followSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null ) {
            float step = followSpeed * Time.deltaTime;
            Vector3 target = player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * step);
        } else {
            rb.velocity = new Vector2(0, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        
    }
}
