using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    //private float minY = -0.0075f;
    //private float maxY = 100f;

    //private float minX = 0.0f;
    //private float maxX = 100f;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
       
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
