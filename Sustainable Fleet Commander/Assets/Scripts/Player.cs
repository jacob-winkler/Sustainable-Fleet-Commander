using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody2D ship_rb;
    public float rotationSpeed;
    public float thrust;
    public Sprite sp_thrust;
    public Sprite sp_left;
    public Sprite sp_right;
    public Sprite sp_default;
    public SpriteRenderer sp_rend;

    public GameObject bullet;

    void Start()
    {
        sp_rend = GetComponent<SpriteRenderer>();
        ship_rb = GetComponent<Rigidbody2D>();
        rotationSpeed = 100.0f;
        thrust = 4.5f;
    }

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

    void OnTriggerEnter2D(Collider2D c)
    {

        // Anything except a bullet is an asteroid
        if (c.gameObject.tag != "Bullet")
        {
            //AudioSource.PlayClipAtPoint(crash, Camera.main.transform.position);

            // Move the ship to the centre of the screen
            transform.position = new Vector3(0, 0, 0);

            // Remove all velocity from the ship
            GetComponent<Rigidbody2D>().
                velocity = new Vector3(0, 0, 0);
        }
    }

    void ShootBullet()
    {

        // Spawn a bullet
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        // Play a shoot sound
        //AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }
}
