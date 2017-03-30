/* Class for the Planet Mining action
 * 
 * Can be applied to any planet.
 * See Planet class for further explanation
 * 
 * Produces precious element resources and gives the planet an economic
 * boost, producing credits also. Harms both itself and its star
 * 
 * REQUIREMENTS:
 *  1. (5) Mining Robots 
 *  2. (1) Engineer
 * 
 * OUTPUTS (per turn):
 *  1. (.2) Star cost
 *  2. (.5) Planet cost
 *  3. (100) Credits
 *  4. (50) Precious Elements
 *  
 * **All attributes have been left public for testing purposes within the
 * Unity game engine.
 * 
 */ 

using UnityEngine;
using System.Collections;

public class PlanetMining : MonoBehaviour, IAction {
    public int remainingDuration = 1; // # of turns left
    
    //requirements to execute action
    public int requiredBots = 5;
    public int requiredEngis = 1;
    public int requiredCredits = 0;
    
    //outputs per turn
    public float starCost = .2f;
    public float planetCost = .5f;
    public int creditOutput = 100; //per turn
    public int PEoutput = 50;

	/* ------------------------------------------------------------------------------ *
	 * >Function: checks whether the action has completed yet					      *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None                                                                   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: true if the action's duration is 0 or less, false otherwise		      *
	 * ------------------------------------------------------------------------------ */
    public bool finished()
    {
        if (remainingDuration <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: Applies the action to the planet it's been assigned to, updating	  *
	 * 			  total outputs and costs of the planet				    		      *
	 * ------------------------------------------------------------------------------ *
	 * >Input: The action's assigned planet                                           *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void apply(Planet owner)
    {
        owner.updateTotalCreditOutput(creditOutput);
        owner.updateTotalPEOutput(PEoutput);

        owner.updateTotalStarCost(starCost);
        owner.updateTotalPlanetCost(planetCost);
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the required mining bots to initiate the action	      *
	 * ------------------------------------------------------------------------------ */
    public int getBotReqs()
    {
        return requiredBots;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the required engineers to initiate the action	    	  *
	 * ------------------------------------------------------------------------------ */
    public int getEngiReqs()
    {
        return requiredEngis;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the required credits to assign the action	    		  *
	 * ------------------------------------------------------------------------------ */
    public int getCreditReqs()
    {
        return requiredCredits;
    }
}
