using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SubGoal {
    public Dictionary<string, int> sgoals;
    public bool remove;

    //takes in a string int value pair, and whether it will be removed after completion
    public SubGoal(string s, int i, bool r) {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(s, i);
        remove = r;
    }
}

public class gAgent : MonoBehaviour {
    public List<gAction> actions = new List<gAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();

    gPlanner planner;
    Queue<gAction> actionQueue;
    public gAction currentAction;
    SubGoal currentGoal;

    void Start() {
        gAction[] acts = this.GetComponents<gAction>();
        foreach(gAction a in acts) { actions.Add(a); }
    }

    void LateUpdate() {
        
    }
}
