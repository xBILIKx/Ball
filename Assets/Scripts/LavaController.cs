using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public Vector3 respawnPlayerPosition;
    public Vector3 respawnCameraPosition;
    public GameObject player;
    public GameObject _camera;
    BallController bc;
    private void Start()
    {
        bc = player.GetComponent<BallController>();
    }

    public void SetPosition()
    {
        respawnPlayerPosition = player.transform.position;
        respawnCameraPosition = _camera.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            player.transform.position = respawnPlayerPosition;
            _camera.transform.position = respawnCameraPosition;
#if UNITY_STANDALONE 
            ////bc.movement = Vector3.zero;
            //bc.rb.AddForce(-bc.movement);
            bc.rb.velocity = Vector3.zero;
#elif UNITY_ANDROID
            bc.gravity = Vector3.zero;
#endif
        }
    }
}
