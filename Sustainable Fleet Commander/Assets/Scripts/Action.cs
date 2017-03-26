using UnityEngine;
using System.Collections;

public interface IAction {
    bool finished();
    void apply(Planet owner);
    int getBotReqs();
    int getEngiReqs();
    int getCreditReqs();
}
