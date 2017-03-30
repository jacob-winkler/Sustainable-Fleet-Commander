/* General interface for action classes that can be applied to planets
 * and star systems
 * 
 * Actions generate resources to be used by the player, but also have
 * associated costs. See the planet class for further explanation.
 * 
 * TO DO: Change interface name and update other classes. I've recently 
 * 		  discovered that IAction is an already existing C# interface and 
 * 		  that this overrides it. Need to do this while the code base is
 *        still small.
 */ 

using UnityEngine;
using System.Collections;

public interface IAction {
    bool finished();
    void apply(Planet owner);
    int getBotReqs();
    int getEngiReqs();
    int getCreditReqs();
}
