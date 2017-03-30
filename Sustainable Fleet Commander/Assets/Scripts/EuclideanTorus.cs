/* Simple script for our moving objects to keep objects within a set
 * boundary (20x16 area) teleporting the object to the opposite border when
 * a border is passed.
 */ 

using UnityEngine;
using System.Collections;

public class EuclideanTorus : MonoBehaviour {

	// Update is called once per frame
    void Update()
    {
        // Teleport the game object to opposite border
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10, transform.position.y, 0);
        }
        else if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, transform.position.y, 0);
        }

        else if (transform.position.y > 8)
        {
            transform.position = new Vector3(transform.position.x, -8, 0);
        }

        else if (transform.position.y < -8)
        {
            transform.position = new Vector3(transform.position.x, 8, 0);
        }
    }
}
