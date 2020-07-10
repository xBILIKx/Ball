using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public UnityEvent openDoor = new UnityEvent();
    public float Speed = 3.4f;
    public int coinsCollected;

    private Rigidbody rb;

    void Start()
    {
        coinsCollected = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontalAxis, 0, verticalAxis) * Speed);
#elif UNITY_ANDROID
        Vector3 gravity = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 9.81f;
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
