using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deck : MonoBehaviour, IPointerDownHandler {
    public List<GameObject> cards;
    private static System.Random rng = new System.Random();

    void Start() {
        this.Shuffle();
    }

    void Shuffle() {
        int n = cards.Count;
        while(n > 1) {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    public void OnPointerDown(PointerEventData edata)
    {
        //draws card by removing it then instantiating it
        GameObject topCard = cards[0];
        cards.RemoveAt(0);

        GameObject newCard = Instantiate(topCard, this.transform.position, this.transform.rotation);
        newCard.transform.parent = this.transform.parent;

    }
}
