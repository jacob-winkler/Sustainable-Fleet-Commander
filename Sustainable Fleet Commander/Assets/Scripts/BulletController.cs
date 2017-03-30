/* Bullet control class that adds a force to newly created bullets and
 * destroys them after 1.5s of existence.
 */ 

using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    //timed self destruct
        Destroy (gameObject, 1.5f);
 
        // Push the bullet in the direction it is facing
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
    }
}
