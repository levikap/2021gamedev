using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform transform;
    Vector3 position;
    float speed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        transform = this.GetComponent<Transform>();
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        UnityEngine.Debug.Log("Vertical " + moveVertical);
        UnityEngine.Debug.Log("Horizontal " + moveHorizontal);


        transform.Translate(new Vector3(moveHorizontal * speed * Time.deltaTime, moveVertical * speed * Time.deltaTime, 0));

    }
}
