using UnityEngine;
using System.Collections;

public class PlanetMining : MonoBehaviour, IAction {
    public int remainingDuration = 1; // # of turns left
    public int requiredBots = 5;
    public int requiredEngis = 1;
    public int requiredCredits = 0;
    public float starCost = .2f;
    public float planetCost = .5f;
    //public string title;
    //public int id;
    public int creditOutput = 100; //per turn
    public int PEoutput = 50;

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

    public void apply(Planet owner)
    {
        owner.updateTotalCreditOutput(creditOutput);
        owner.updateTotalPEOutput(PEoutput);

        owner.updateTotalStarCost(starCost);
        owner.updateTotalPlanetCost(planetCost);
    }

    public int getBotReqs()
    {
        return requiredBots;
    }

    public int getEngiReqs()
    {
        return requiredEngis;
    }

    public int getCreditReqs()
    {
        return requiredCredits;
    }
}
