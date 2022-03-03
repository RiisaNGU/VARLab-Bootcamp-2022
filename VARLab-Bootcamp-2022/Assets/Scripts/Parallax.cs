using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallax;

    void Awake()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallax));       // relative to cam, repeat BG
        float dist = (cam.transform.position.x * parallax);

        transform.position = new Vector3(startpos + dist, 0.0f, transform.position.z);

        /// <summary>Repeat BG
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
