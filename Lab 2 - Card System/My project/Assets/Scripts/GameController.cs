using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour {
    public int cardCount = 0;
    public TMP_Text txtFeedback;

    public void CardDestroyed() {
        cardCount--;
        this.UpdateCountDisplay();
        if(cardCount <= 0) {
            //you lose (not really)
        }
    }
    
    public void CardAdded() {
        cardCount++;
        this.UpdateCountDisplay();
    }

    public void UpdateCountDisplay() {
        txtFeedback.text = cardCount.ToString();
    }
}
