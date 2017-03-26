using UnityEngine;
using System.Collections;

public class textTrigger : MonoBehaviour {
    public GameController gamecontroller;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag != "Bullet")
        {
            gamecontroller.finishTurn();
        }
    }
}
