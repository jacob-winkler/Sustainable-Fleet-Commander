using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetViewControl : MonoBehaviour {
    public float starhealth;

    public Planet selectedPlanet;
    public PlanetMining selectedAction;
    public GameController gamecontroller;

    public Text tstarhealth;
    public Text availableCredits;
    public Text availablePE;
    //selected action panel text
        //public Text sa_creditreq;
        //public Text sa_pereq;
    public Text sa_engireq;
    public Text sa_botreq;
    public Text sa_creditout;
    public Text sa_peout;
    public Text sa_starcost;
    public Text sa_planetcost;
    //selected planet resource output panel text
    public Text sp_creditout;
    public Text sp_peout;
    public Text sp_planetcost;
    public Text sp_starcost;
    public Text sp_health;
    public Text sp_engis;
    public Text sp_bots;

    //UI Buttons
    public Button initiateAction;

	// Use this for initialization
	void Start() {
        selectedPlanet.turnUpdate();
        selectedPlanet.modifyResources();
        updatePlanetResourceText();
        updatePlanetOutputText();
        updateGlobalResourceText();
        updateStarHealth(-selectedPlanet.totalStarCost);
        tstarhealth.text = "" + starhealth + "/2500";
        checkAction();
	}
	
    public void updateStarHealth(float value)
    {
        starhealth += value;
    }
    
    //checks whether the selected planet can perform the selected action
    public bool checkAction()
    {
        updateActionText();
        if(selectedAction != null)
        {
            if (gamecontroller.getCredits() >= selectedAction.getCreditReqs() &&
                selectedPlanet.getBotsAvailable() >= selectedAction.getBotReqs() &&
                selectedPlanet.getEngisAvailable() >= selectedAction.getEngiReqs())
            {
                initiateAction.interactable = true;
                return true;
            }
        }
        initiateAction.interactable = false;
        return false;
    }

    public void initializeAction()
    {
        if (checkAction())
        {
            gamecontroller.updateCredits(-selectedAction.getCreditReqs());
            selectedPlanet.updateBotsAvailable(-selectedAction.getBotReqs());
            selectedPlanet.updateEngisAvailable(-selectedAction.getEngiReqs());
            selectedPlanet.addAction(selectedAction);
            selectedAction.apply(selectedPlanet);
            updatePlanetOutputText();
            updatePlanetResourceText();
            updateGlobalResourceText();
            checkAction();
        }
    }

    public void updateActionText()
    {
        //update selected action text
        sa_engireq.text = "Engineers: " + selectedAction.getEngiReqs();
        sa_botreq.text = "Mining Bots: " + selectedAction.getBotReqs();
        //update action required credits text
        sa_creditout.text = "Credits: " + selectedAction.creditOutput;
        sa_peout.text = "Precious Elements: " + selectedAction.PEoutput;
        sa_starcost.text = "Star Damage: " + selectedAction.starCost;
        sa_planetcost.text = "Planet Damage: " + selectedAction.planetCost;
    }

    public void updatePlanetOutputText()
    {
        sp_creditout.text = "Credits: " + selectedPlanet.getCreditOutput();
        sp_peout.text = "Precious Elements: " + selectedPlanet.getPEOutput();
        sp_planetcost.text = "Planet Damage: " + selectedPlanet.getPlanetCost();
        sp_starcost.text = "Star Damage: " + selectedPlanet.getStarCost();
    }

    public void updatePlanetResourceText()
    {
        sp_health.text = "" + selectedPlanet.getHealth() + "/500";
        sp_engis.text = "Engineers: " + selectedPlanet.getEngisAvailable();
        sp_bots.text = "Mining Bots: " + selectedPlanet.getBotsAvailable();
    }

    public void updateGlobalResourceText()
    {
        availableCredits.text = "Credits: " + gamecontroller.getCredits();
        availablePE.text = "Precious Elements: " + gamecontroller.getPElements();
    }
}
