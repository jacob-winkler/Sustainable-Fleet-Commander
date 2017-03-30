/* Class to control global aspects of the game (global resources only for
 * now) not related to any single object
 * 
 * See the planet class for further explanation.
 * 
 * All attributes have been left public for testing purposes within the
 * Unity game engine.
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * Future Plans: Control game progress and determine what levels to load
 * 				 for each successive turn
 */ 

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public int credits;
    public int pelements; //precious element resource

	/* ------------------------------------------------------------------------------ *
	 * >Function: grab the number of precious element resources available		      *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None                                                                   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: integer value of the pelements attribute			                  *
	 * ------------------------------------------------------------------------------ */
	public int getPElements()
    {
        return pelements;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: grab the number of credit resources available				          *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None                                                                   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: integer value of the credits attribute				                  *
	 * ------------------------------------------------------------------------------ */
    public int getCredits()
    {
        return credits;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the credits attribute by adding the integer parameter 	  *
	 * 			  value to the attribute.											  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the credits attribute         *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateCredits(int value)
    {
        credits += value;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the pelements attribute by adding the integer parameter    *
	 * 			  value to the attribute.											  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the pelements attribute       *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updatePElements(int value)
    {
        pelements += value;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: Loads the space combat scene, initiating the next turn			  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None															          *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void nextTurn()
    {
        Application.LoadLevel("asteroidsCombat");
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: Loads the star system (resource management scene), initiating the   *
	 * 			  next turn			  												  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None															          *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void finishTurn()
    {
        Application.LoadLevel("StarSystem");
    }
}
