using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCard : Card {
    private int life = 2;

    void Start() {
        this.CardCapabilities.Add(new SoundFeature());
    }

    void OnPlay() {
        GameObject other = GameObject.FindWithTag("Card");
        
        if (other) {
            other.SendMessage("Activate");
            life++;
        }
    }

    void OnActivate() {
        life--;

        if (life <= 0) {
            this.Erase();
        }
    }

    void OnDestroy() {
        GameObject.Find("SFX").transform.Find("FireSound").GetComponent<AudioSource>().Play();
    }
}
