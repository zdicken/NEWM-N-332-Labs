using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class gAction : MonoBehaviour {
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public GameObject targetTag;
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public UnityEngine.AI.NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;

    public bool running = false;

    public gAction() {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    public void Awake() {
        agent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(preConditions != null) {
            foreach (WorldState w in preConditions) { preconditions.Add(w.key, w.value); }
        }

        if (afterEffects != null)
        {
            foreach (WorldState w in afterEffects) { effects.Add(w.key, w.value); }
        }
    }

    public bool isAchieveable() {
        return true;
    }

    public bool isAchieveableGiven(Dictionary<string, int> conditions) {
        foreach(KeyValuePair<string, int> p in preconditions) {
            if (!conditions.ContainsKey(p.Key)) { return false; }
        }
        return true;
    }

    public abstract bool prePerform();
    public abstract bool postPerform();
}
