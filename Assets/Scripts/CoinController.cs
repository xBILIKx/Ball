using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public int Value = 1;

    public float RotationRate = 1.0f;
    Vector3 rotationAxis = new Vector3(0, 1, 0);


    public void Vanish()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rotationAxis += Random.onUnitSphere / 50;


        transform.Rotate(rotationAxis, RotationRate);
    }
}
