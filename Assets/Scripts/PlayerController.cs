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
    GameObject ResetPoint;
    bool resetting = false;
    bool grounded = true;
    Color originalColor;


    //Controllers
    SoundController soundController;
    GameControlller gameControlller;

    int totalPickups;
    private bool wonGame = false;
    [Header("UI")]
    public GameObject gameoverScreen;
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
        gameoverScreen.SetActive(false);
        ResetPoint = GameObject.Find("Reset Point");
        soundControllor = FindObjectOfType<SoundControllor>();
        gameControllor = FindObjectOfType<GameControllor>();

        originalColor = GetComponent<Renderer>().material.color;
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
        if (resetting)
            return;

        if (gameControlller.controlType == ControlType.WorldTilt)
            return;

        if (grounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
                grounded = true;
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Ground"))
                grounded = false;
        }

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
            soundController.PlayPickupSound();
            Destroy(other.gameObject);
        }
       
     }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            soundController.PlayCollisionSound(collision.gameObject);
        }
    }

    public IEnumerator ResetPlayer()
    {
        resetting = true;
        GetComponent<Renderer>().material.color = Color.black;
        rb.velocity = Vector3.zero;
        Vector3 startPos = transform.position;
        float resetSpeed = 1f;
        var i = 0.0f;
        var rate = 1.0f / resetSpeed;
        while (i<1.0f)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, ResetPoint.transform.position, i);
            yield return null;
        }
        GetComponent<Renderer>().material.color = originalColor;
        resetting = false;
    }

    void CheckPickups()
    {
        //Display the pickupcount to the player
        Score_text.text ="Peepy Left:"+ pickupCount .ToString() + "/" + totalPickups.ToString();
       
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

    void WinGame()
    {
        gameoverScreen.SetActive(true);
        WinText.text = "YOU ARE A WINNER!!";
        soundController.PlayWinSound();
    } 
        
}   
