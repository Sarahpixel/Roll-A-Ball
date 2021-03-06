using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    public int pickupCount;
    int totalPickups;
    private bool wonGame = false;
    [Header("UI")]
    public TMP_Text Score_text;
    public TMP_Text WinText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public Image pickupFill;
    public float pickupChunck;
   
    void Start()
    {
        //turn off our win panel object
        winPanel.SetActive(false);
        //turn on our in game panel
        inGamePanel.SetActive(true);
        //gets the rigidbody componet attached to this game object
        rb = GetComponent<Rigidbody>();
        // Work out how many pickups are in the scene and store in (pickup count)
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;
        //Displays the pick up count
        totalPickups = pickupCount;
        //work out the amount of fill for our pickup fill
        pickupChunck =  1.0f/totalPickups;
        pickupFill.fillAmount = 0;
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
            //increase the fill amount of our pickup fill image
            pickupFill.fillAmount = pickupFill.fillAmount + pickupChunck;
            //Display the pickups to the user
            CheckPickups();

            Destroy(other.gameObject);
        } 
     }
    void CheckPickups()
    {
        //Display the pickupcount to the player
        Score_text.text ="Cubes Left:"+ pickupCount .ToString() + "/" + totalPickups.ToString
            ();
       
        //Check if the pickupcount ==0 
         if (pickupCount==0)
         {
            //if pickup count ==0 display win message, remove contols from player??
          winPanel.SetActive(true);
            //turn on our in game panel
            inGamePanel.SetActive(false);
            //remove the player controls
            wonGame = true;
            //set the velocity of the rigid body to zero
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
         }

    }
  
    public void ResetGame()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene
        (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    

    

    //Create a win condition that happens when pickupcount == 0


    

    
        
}   
