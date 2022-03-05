using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VARLabBootCamp2022
{
    public class CameraController : MonoBehaviour
    {
        public GameObject player;
        private float maxCamY = -2.5f;

        private Vector3 offset;

        void Awake()
        {
            offset = transform.position - player.transform.position;
        }
        void LateUpdate()
        {
            // if player Y coord is below a certain point, stop the camera -> for falling out of bounds
            if (player.transform.position.y > maxCamY)
            {
                transform.position = player.transform.position + offset;
            }

        }
    }
}
