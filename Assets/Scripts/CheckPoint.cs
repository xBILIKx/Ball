using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent setCheckPoint = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            setCheckPoint.Invoke();
            Destroy(gameObject);
        }
    }
}
