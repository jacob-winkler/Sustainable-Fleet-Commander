/* Simple script for player movement and collision during combat stage
 * 
 * **All attributes have been left public for testing purposes within the
 * Unity game engine.
 */ 

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody2D ship_rb;
    public float rotationSpeed;
    public float thrust;
    
    //ship sprites for different states of movement
    public Sprite sp_thrust;
    public Sprite sp_left;
    public Sprite sp_right;
    public Sprite sp_default;
    
    public SpriteRenderer sp_rend;

    public GameObject bullet;

	//Initializes the player's ship grabbing its associated components
    void Start()
    {
        sp_rend = GetComponent<SpriteRenderer>();
        ship_rb = GetComponent<Rigidbody2D>();
        rotationSpeed = 100.0f;
        thrust = 4.5f;
    }

	/* Constantly loops checking for movement/weapong inputs, updates ship's
	 * and movement accordingly
	 */ 	 
    void FixedUpdate()
    {
        //Ship Rotation
        if (Input.GetAxis("Horizontal") == -1)
        {
            sp_rend.sprite = sp_left;
        } 
        if (Input.GetAxis("Horizontal") == 1)
        {
            sp_rend.sprite = sp_right;
        }
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

        //Thrust action
        if (Input.GetAxis("Vertical") == 1)
        {
            sp_rend.sprite = sp_thrust;
            ship_rb.AddForce(transform.up * thrust * Input.GetAxis("Vertical"));
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") != 1)
        {
            sp_rend.sprite = sp_default;
        }
    }

	//checks for collisions with anything other than a bullet (will do damage in the future)
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {
            // Move the ship to the centre of the screen
            transform.position = new Vector3(0, 0, 0);

            // Remove all velocity from the ship
            GetComponent<Rigidbody2D>().
                velocity = new Vector3(0, 0, 0);
        }
    }

	//produces projectile objects
    void ShootBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
