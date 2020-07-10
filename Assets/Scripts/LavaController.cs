using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    public Vector3 respawnPlayerPosition;
    public Vector3 respawnCameraPosition;
    public GameObject player;
#pragma warning disable CS0108
    public GameObject camera;
#pragma warning restore CS0108

    public void SetPosition()
    {
        respawnPlayerPosition = player.transform.position;
        respawnCameraPosition = camera.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            player.transform.position = respawnPlayerPosition;
            camera.transform.position = respawnCameraPosition;
        }
    }
}
