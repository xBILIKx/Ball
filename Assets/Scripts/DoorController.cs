using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float step = 0.1f;
    public float upperLevel = 5;
    public int cost;
    public BallController bc;
    public void StartDoorAnim()
    {
        if(bc.coinsCollected >= cost)
            StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        yield return new WaitForEndOfFrame();
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, upperLevel, transform.position.z), step * Time.deltaTime);
        if (transform.position.y < upperLevel)
            StartCoroutine(OpenDoor());
    }
}
