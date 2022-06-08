using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //gets the rigidbody componet attached to this game object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //store the horizontal axis value in a float
        float moveHorizontal = Input.GetAxis("Horizontal");
        //store the vertical axis value in a float
        float moveVertical = Input.GetAxis("Vertical");

        //creates a new vector 3 based on the horizotal and vertical values
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        

        //add force to our rigidbody from our movement multiplying the movement by a number
        rb.AddForce(movement* 5);
    }
}
