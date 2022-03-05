using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VARLabBootCamp2022
{
    public class Snowball : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // destries the object if it hits the 
            if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "OutOfBounds")
            {
                Destroy(gameObject);
            }

            if (collision.gameObject.tag == "Snowman")
            {
                Debug.Log("Hit");
            }
        }
    }
}
