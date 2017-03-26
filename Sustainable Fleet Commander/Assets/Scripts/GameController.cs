using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public int credits;
    public int pelements;

    public int getPElements()
    {
        return pelements;
    }

    public int getCredits()
    {
        return credits;
    }

    public void updateCredits(int value)
    {
        credits += value;
    }

    public void updatePElements(int value)
    {
        pelements += value;
    }

    public void nextTurn()
    {
        Application.LoadLevel("asteroidsCombat");
    }

    public void finishTurn()
    {
        Application.LoadLevel("StarSystem");
    }
}
