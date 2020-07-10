using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ball;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ball.transform.position; 
    }

    void Update()
    {
        transform.position = ball.transform.position + offset;
    }
}
