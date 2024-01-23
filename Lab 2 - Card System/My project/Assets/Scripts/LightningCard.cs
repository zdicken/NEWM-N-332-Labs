using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCard : Card {
    public GameObject nextToGenerate;

    void OnPlay() {
        base.OnPlay();

        GameObject other = GameObject.FindWithTag("Card");

        if (other) {
            other.SendMessage("Activate");
            other.SendMessage("Erase");
        }
    }

    void OnDestroy() {
        GameObject newLightning = Instantiate(nextToGenerate, this.transform.position, this.transform.rotation);
        newLightning.transform.parent = this.transform.parent;
        newLightning.SendMessage("OnPlay");
    }
}
