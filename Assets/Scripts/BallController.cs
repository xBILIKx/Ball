using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public UnityEvent openDoor = new UnityEvent();
#if UNITY_STANDALONE 
    public Vector3 movement;
#elif UNITY_ANDROID
    public Vector3 gravity;
#endif
    public float Speed = 3.4f;
    public int coinsCollected;


    public Rigidbody rb;

    void Start()
    {
        coinsCollected = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
#if UNITY_STANDALONE 
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalAxis, 0, verticalAxis) * Speed;
        rb.AddForce(movement);
#elif UNITY_ANDROID
        gravity = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 9.81f;
        rb.AddForce(gravity, ForceMode.Acceleration);
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinController coin = other.GetComponent<CoinController>();
        if(coin != null)
        {
            coinsCollected += coin.Value;
            coin.Vanish();
            openDoor.Invoke();
        }
    }
}
