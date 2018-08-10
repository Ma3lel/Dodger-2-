using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    private int score;
    public float timer;
    public float speed;             //Floating point variable to store the player's movement speed.
   Text scoreText;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    bool isDead;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }
    void OnCollisionEnter2D(Collision2D col)
    { if (col.gameObject.tag == "Respawn")
        {
            speed = 0;
            SceneManager.LoadScene(2);
        }
    }
    //Edit the Update function to only recieve input when the player is not dead
    void Update()
    {

        //DO NOT COPY PASTE THIS CODE, Edit the existing one

        //Only move if the player taps the screen and the bird is not dead
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            // Reset Velocity 
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
            //Add UP force to the bird
            rb2d.AddForce(Vector2.up * speed);
        }

        timer = Time.time;

        while (speed != 0)
        {
            timer += Time.deltaTime;
            score++;

            scoreText.text = score.ToString();

        }
    }
   
}