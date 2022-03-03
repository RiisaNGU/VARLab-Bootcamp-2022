using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    //private GameObject snowball;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Snowman")
        {
            Debug.Log("Hit");
        }
    }
}
