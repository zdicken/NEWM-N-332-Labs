using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int scoreValue = 0;
    public List<Feature> cardCapabilities;

    public void Activate() {
        //SendMessageOptions.DontRequireReciever throws an error for some unknown reason
        this.SendMessage("OnActivate");

        foreach (Feature capability in cardCapabilities) {
            capability.Activate();
        }
    }

    public void OnPlay() {
        GameObject.FindWithTag("GameController").GetComponent<GameController>().CardAdded();
        foreach (Feature capability in cardCapabilities) {
            capability.Play();
        }
    }

    public void Erase() {
        this.SendMessage("OnDestroy");
        GameObject.FindWithTag("GameController").GetComponent<GameController>().CardDestroyed();
        Destroy(this.gameObject);
    }
}
