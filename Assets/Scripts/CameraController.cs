using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        //Set the offset to the cameras position minus the players position
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Set the transform to the camera to that of the player
        transform.position = player.transform.position + offset;

    }
}
