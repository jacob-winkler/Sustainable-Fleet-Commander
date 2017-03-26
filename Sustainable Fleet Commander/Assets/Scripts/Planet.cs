using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {
    
    public int engiTotal;
    public int engiAvailable;
    public int mbotTotal;
    public int mbotAvailable;
    public int basePEOutput;
    public int totalPEOutput;
    public int baseCreditOutput;
    public int totalCreditOutput;
    public float baseStarCost;
    public float totalStarCost;
    public float basePlanetCost;
    public float totalPlanetCost;
    public float starDistance;
    public float health;

    private List<IAction> actions = new List<IAction>();
    public GameController gamecontroller;

    //adds a new action to action list. Updates available bots and engineers if planet has adequate supply
	public void addAction(IAction newAction) {
        actions.Add(newAction);
	}
	
	// turnUpdate is called after level completion
	public void turnUpdate () {
        totalCreditOutput = baseCreditOutput;
        totalPEOutput = basePEOutput;
        totalPlanetCost = basePlanetCost;
        totalStarCost = baseStarCost;

        for (int i = 0; i < actions.Count; i++)
        {
            actions[i].apply(this);
            if (actions[i].finished())
            {
                actions.Remove(actions[i]);
            }
        }
	}

    public float getHealth()
    {
        return health;
    }

    public int getCreditOutput()
    {
        return totalCreditOutput;
    }

    public int getPEOutput()
    {
        return totalPEOutput;
    }

    public float getPlanetCost()
    {
        return totalPlanetCost;
    }

    public float getStarCost()
    {
        return totalStarCost;
    }

    public int getBotsAvailable()
    {
        return mbotAvailable;
    }

    public int getEngisAvailable()
    {
        return engiAvailable;
    }

    public void updateBotsAvailable(int value)
    {
        mbotAvailable += value;
    }

    public void updateEngisAvailable(int value)
    {
        engiAvailable += value;
    }

    public void updateTotalPEOutput(int value)
    {
        totalPEOutput += value;
    }

    public void updateTotalCreditOutput(int value)
    {
        totalCreditOutput += value;
    }

    public void updateTotalStarCost(float value)
    {
        totalStarCost += value;
    }

    public void updateTotalPlanetCost(float value)
    {
        totalPlanetCost += value;
    }

    public void modifyStarHealth(PlanetViewControl pviewcontrol)
    {
        pviewcontrol.updateStarHealth(-totalStarCost);
    }

    public void modifyResources()
    {
        health += -totalPlanetCost;
        gamecontroller.updateCredits(totalCreditOutput);
        gamecontroller.updatePElements(totalPEOutput);
    }
}
