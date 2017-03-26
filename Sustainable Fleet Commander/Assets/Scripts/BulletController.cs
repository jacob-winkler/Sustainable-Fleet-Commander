using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    //timed self destruct
        Destroy (gameObject, 1.0f);
 
        // Push the bullet in the direction it is facing
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400);
    }
}
