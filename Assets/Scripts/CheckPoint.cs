using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent setCheckPoint = new UnityEvent();
    public GameObject checkPointText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            setCheckPoint.Invoke();
            StartCoroutine(CheckPointText());
        }
    }

    IEnumerator CheckPointText()
    {
        checkPointText.SetActive(true);
        yield return new WaitForSeconds(3);
        checkPointText.SetActive(false);
        Destroy(gameObject);
    }
}
