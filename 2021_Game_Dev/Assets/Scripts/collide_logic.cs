using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide_logic : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider triggerer)
    {
        Debug.Log("trigger entered");
        if(triggerer.gameObject.name == "Enemy")
        {
            Destroy(triggerer.gameObject);
        }
    }
}
