/* Class that serves as the controller for the resource management stage,
 * which is also the planet/star-system view.
 * 
 * The view of a star system's planets and the associated controls within
 * this view. Currently updates all of the text within this view. Encapsulates
 * all of the Planets within the star system and initializes all the behaviors
 * associated with each planet at the end of each turn. A turn ends when
 * you leave the combat stage of the game and move on to the resource
 * management stage (the stage that this class controls)
 * 
 * **All attributes have been left public for testing purposes within the
 * Unity game engine.
 * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * TO-DO:
 * 1.) Make a separate class for all text updates and migrate them.
 * 2.) Add a fully functioning action selector
 * 3.) Add a fully functioning planet selector
 * 
 */ 

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
	/* ------------------------------------------------------------------------------ *
	 * >Function: Performs all necessary initializations for when you first enter the *
	 * 			  star-system view. Updates all planets resources and outputs (will   *
	 * 			  need to refactor once multiple planets are implemented) as well as  *
	 * 			  star health. Updates all on-screen text and performs a check on the *
	 *     		  currently selected action.										  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None                                                                   *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None															      *
	 * ------------------------------------------------------------------------------ */
	void Start() {
        selectedPlanet.turnUpdate();
        selectedPlanet.modifyResources();
        selectedPlanet.modifyStarHealth();
        updatePlanetResourceText();
        updatePlanetOutputText();
        updateGlobalResourceText();
        updateStarHealth(-selectedPlanet.totalStarCost);
        tstarhealth.text = "" + starhealth + "/2500";
        checkAction();
	}
	
	/* ------------------------------------------------------------------------------ *
	 * >Function: Modifies the starhealth attribute    								  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: Float value to modify the star health by								  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None												                  *
	 * ------------------------------------------------------------------------------ */
    public void updateStarHealth(float value)
    {
        starhealth += value;
    }
    
    /* ------------------------------------------------------------------------------ *
	 * >Function: checks whether there are adequate resources to assign the selected  *
	 * 			  action to the selected planet and updates the interactability of	  *
	 * 			  the intiate action button	accordingly								  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None																	  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: True if the action can be performed false otherwise					  *
	 * ------------------------------------------------------------------------------ */
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

	/* ------------------------------------------------------------------------------ *
	 * >Function: Initializes the selected action for the selected planet, updating	  *
	 * 			  all associated resources and text. This function is executed when	  *
	 * 			  the initiate action button is clicked.							  *
	 * ------------------------------------------------------------------------------ *
	 * >Input: None																	  *
	 * ------------------------------------------------------------------------------ *
	 * >Output: None			  													  *
	 * ------------------------------------------------------------------------------ */
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

	//Updates associated action text for the selected action
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
	
	//updates the associated planet output text for the selected planet
    public void updatePlanetOutputText()
    {
        sp_creditout.text = "Credits: " + selectedPlanet.getCreditOutput();
        sp_peout.text = "Precious Elements: " + selectedPlanet.getPEOutput();
        sp_planetcost.text = "Planet Damage: " + selectedPlanet.getPlanetCost();
        sp_starcost.text = "Star Damage: " + selectedPlanet.getStarCost();
    }

	//updates the associated planet resources text for the selected planet
    public void updatePlanetResourceText()
    {
        sp_health.text = "" + selectedPlanet.getHealth() + "/500";
        sp_engis.text = "Engineers: " + selectedPlanet.getEngisAvailable();
        sp_bots.text = "Mining Bots: " + selectedPlanet.getBotsAvailable();
    }

	//updates the global resources text
    public void updateGlobalResourceText()
    {
        availableCredits.text = "Credits: " + gamecontroller.getCredits();
        availablePE.text = "Precious Elements: " + gamecontroller.getPElements();
    }
}
