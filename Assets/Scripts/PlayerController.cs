using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    public int pickupCount;
    private bool wonGame = false;
    void Start()
    {
        //gets the rigidbody componet attached to this game object
        rb = GetComponent<Rigidbody>();
        // Work out how many pickups are in the scene and store in (pickup count)
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Display the pickups to the user
        CheckPickups();

    }


    void FixedUpdate()
    {
        //if we have won the game, return the function
        if (wonGame == true)
            return;

        //store the horizontal axis value in a float
        float moveHorizontal = Input.GetAxis("Horizontal");
        //store the vertical axis value in a float
        float moveVertical = Input.GetAxis("Vertical");

        //creates a new vector 3 based on the horizotal and vertical values
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        

        //add force to our rigidbody from our movement multiplying the movement by a number
        rb.AddForce(movement* 5);
    }

   
     private void OnTriggerEnter(Collider other)
     {
        //if we collide witha pickup, destroy the pickup
        if (other.gameObject.CompareTag("Pickup"))
        {
            //Decrement the pickupcount when we collide with the pickup
            pickupCount -= 1;
            //Display the pickups to the user
            CheckPickups();

            Destroy(other.gameObject);
        } 
     }
    void CheckPickups()
    {
        //Display the pickupcount to the player
          Debug.Log("Pickup Count:" + pickupCount);
        //Check if the pickupcount ==0 
         if (pickupCount==0)
         {
            //if pickup count ==0 display win message, remove contols from player??
            Debug.Log("You Win");
            //remove the player controls
            wonGame = true;
            //set the velocity of the rigid body to zero
            rb.velocity = Vector3.zero;
         }

    }
  

    

    

    //Create a win condition that happens when pickupcount == 0


    

    
        
}   
