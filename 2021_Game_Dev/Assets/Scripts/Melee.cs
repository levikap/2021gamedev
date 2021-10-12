using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject melee_field;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("e"))
        {
            Debug.Log("attacking");
            melee();
        }
    }

    private void melee() {
        GameObject inst_melee_field = Instantiate(melee_field);
        inst_melee_field.transform.position = rb.transform.position;
    }
}
