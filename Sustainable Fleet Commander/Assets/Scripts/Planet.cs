/* The Planet class and all of the associated functions of a planet.
 * 
 * Each star system that the player controls contains any number of planets.
 * Planets can have Actions applied to them which generate resources for the
 * player but also have associated costs (to the planet itself and the star
 * from which energy is drawn to perform these actions)
 * 
 * Each planet has its own set of resources specific to itself in the form
 * of engineers and mining robots, which are allocated to actions applied to
 * the planet.
 * 
 * The resource outputs and the planet/star costs are applied after the
 * completion of each combat stage (signifying the end of a turn), where
 * you are then presented with the chance to manage your star systems and
 * their child planets.
 * 
 * **All attributes have been left public for testing purposes within the
 * Unity game engine.
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * TO-DO:
 * 1.) Requirement checks are currently done outside of the planet class.
 *     Want to refactor this later.
 * 2.) Refactor turnUpdate function
 */ 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {
    
    public int engiTotal;			//total number of engineers
    public int engiAvailable;		//engineers available for allocation
    public int mbotTotal;			//total number of mining bots
    public int mbotAvailable;		//mining bots available for allocation
    public int basePEOutput;		//base precious element output
    public int totalPEOutput;		//precious element output after actions are applied
    public int baseCreditOutput;	//base credit output
    public int totalCreditOutput;	//credit output after actions are applied
    public float baseStarCost;		//base star health cost
    public float totalStarCost;		//star health cost after actions are applied
    public float basePlanetCost;	//base planet health cost
    public float totalPlanetCost;	//planet health cost after actions are applied
    //public float starDistance;		//distance between planet and star
    public float health;			//current planet health

	//running list of actions that have been applied to the planet
    private List<IAction> actions = new List<IAction>();
    public GameController gamecontroller;

    /* ------------------------------------------------------------------------------ *
	 * >Function: Adds a new action to the planets action list		      			  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: an IAction action                                                      *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
	public void addAction(IAction newAction) {
        actions.Add(newAction);
	}
	
	/*** REFACTOR NEEDED (Reseting the totals is unneccessary -- just remove finished
	 *   actions and update accordingly)
	 * ------------------------------------------------------------------------------ *
	 * >Function: 1.) This function is called at the beginning of a new turn		  *
	 * 			  2.) Resets total costs and outputs of the planets to their base 	  *
	 * 			  values, iterates through the action list and updates the totals 	  *
	 * 			  accordingly for each action that didn't finish this turn.			  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None                                                                   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: integer value of the pelements attribute			                  *
	 * ------------------------------------------------------------------------------ */
	public void turnUpdate () {
        totalCreditOutput = baseCreditOutput;
        totalPEOutput = basePEOutput;
        totalPlanetCost = basePlanetCost;
        totalStarCost = baseStarCost;

        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].finished())
            {
                actions.Remove(actions[i]);
            } else {
				actions[i].apply(this);
			}
        }
	}
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the current health value of the planet   			      *
	 * ------------------------------------------------------------------------------ */
	
    public float getHealth()
    {
        return health;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total number of credits this planet outputs		  *
	 * ------------------------------------------------------------------------------ */
    public int getCreditOutput()
    {
        return totalCreditOutput;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total number of precious elements the planet outputs *
	 * ------------------------------------------------------------------------------ */
    public int getPEOutput()
    {
        return totalPEOutput;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total planet health cost per turn      			  *
	 * ------------------------------------------------------------------------------ */
    public float getPlanetCost()
    {
        return totalPlanetCost;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total star health cost per turn					  *
	 * ------------------------------------------------------------------------------ */
    public float getStarCost()
    {
        return totalStarCost;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total number of mining bots available				  *
	 * ------------------------------------------------------------------------------ */
    public int getBotsAvailable()
    {
        return mbotAvailable;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: getter for the total number of available engineers				  *
	 * ------------------------------------------------------------------------------ */
    public int getEngisAvailable()
    {
        return engiAvailable;
    }
    
	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the mbotAvailable attribute, adding the integer parameter  *
	 * 			  value to the attribute.											  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the mbotAvailable attribute   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateBotsAvailable(int value)
    {
        mbotAvailable += value;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the engiAvailable attribute, adding the integer parameter  *
	 * 			  value to the attribute.											  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the engiAvailable attribute   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateEngisAvailable(int value)
    {
        engiAvailable += value;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the totalPEOutput attribute, adding the integer parameter  *
	 * 			  value to the attribute.											  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the totalPEOutput attribute   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateTotalPEOutput(int value)
    {
        totalPEOutput += value;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the totalCreditOutput attribute, adding the integer 		  *
	 * 			  parameter value to the attribute.									  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Integer value to add to current value of the totalCreditOutput         *
	 * 		   attribute															  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateTotalCreditOutput(int value)
    {
        totalCreditOutput += value;
    }

	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the totalStarCost attribute, adding the integer parameter  *
	 * 			  value to the attribute.									 		  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Float value to add to current value of the totalStarCost attribute     *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateTotalStarCost(float value)
    {
        totalStarCost += value;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: modifies the totalPlanetCost attribute, adding the integer		  *
	 * 			  parameter value to the attribute.									  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Float value to add to current value of the totalPlanetCost attribute   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateTotalPlanetCost(float value)
    {
        totalPlanetCost += value;
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: Subtracts the totalStarCost attribute value from its star's health  *
	 * 			  (which is tracked in the PlanetViewControl class, the class that    *
	 * 			  will call this function.)     									  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: PlanetViewControl object that this planet is a member of				  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void modifyStarHealth(PlanetViewControl pviewcontrol)
    {
        pviewcontrol.updateStarHealth(-totalStarCost);
    }
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: Modifies the resources that this planet contributes to other than	  *
	 * 			  the star's health, which is modified in a separate function. The 	  *
	 * 			  modified resources include the planet's own health, the global      *
	 * 			  credits resource, and the global precious elements resource.		  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None																	  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void modifyResources()
    {
        health += -totalPlanetCost;
        gamecontroller.updateCredits(totalCreditOutput);
        gamecontroller.updatePElements(totalPEOutput);
    }
}
