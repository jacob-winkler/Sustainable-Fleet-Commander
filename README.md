# Sustainable-Fleet-Commander
Space Shooter/Resource Management Sim

To see my code, go to branch Prototype1 then navigate to the following directory
  > Sustainable Fleet Commander/Assets/Scripts

You can run the current prototype by running the executable file available within the "Sustainable Fleet Commander" folder.
Use the default settings for best experience


GAME DESCRIPTION (Not fully implemented)
================
 ~~~~~~~~~~~~~~~
 The first stage
 ~~~~~~~~~~~~~~~
  This is the basic combat stage. Unfortunately there's no real combat. Just a proof of concept.

    You move using WASD or the arrow keys.

    You fire your weapon using left mouse click.

    Follow the on screen instructions to advance to the next stage.

 ~~~~~~~~~~~~~~~~
 The second level
 ~~~~~~~~~~~~~~~~
  This is the resource management stage. The overview of your star system which is revisited after each combat stage.

    *In this stage you have planets (only a single one for now) that each have their own unique resources.
    
    *You can assign a variety of actions (just one action for now) to each planet which have widespread effects in the star    system and potentially in combat, depending on the action.
    
    *Each action modifies the resource output of the planet its attached to.
    
    *You have global resources which are shared across the entire star system (credits and precious elements)
    
    *And you have local planetary resources (engineers and mining robots), unique to each planet, which are allocated to new actions assigned to the planet. They are reacquired by the planet once an action is complete.
    
    *Each planet also has a cost attached to it, doing harm both to itself and to its parent star.
    
    *The panel labeled "Resource Output" tells you what the currently selected planet outputs.
    
    *The panel labeled "Selected Action" shows you the currently selected action, what's required to initiate the action, and what it outputs.
    
    *All outputs are calculated on a turn by turn basis.
    
    *You can click the "assign action" button to assign the current action to the only planet available.
    
    *You can click to "Next Turn" button to return to the combat stage and theoretically progress to the next turn.
    
    *Unfortunately, the "stages" (called scenes) in this game engine don't have an easy way to make the data in each stage persist once you leave a stage and return to it, so I have to implement a data management class which hasn't been done yet.
    
    *Thus currently, when you progress to the next turn, and then come back to the star system overview, it's as if all your prior actions were erased and your star and planet are back to normal.
    
    *In light of this, I give enough starting credits to initiate the planetary mining action 3 times, so that you can watch the resource output screens update in the system overview in real time.
