using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinsCollected : MonoBehaviour
{
    TMP_Text text;

    void Awake() {
        text = GetComponent<TMP_Text>();
    }

    void Update() {
        text.text = "X" + Coin.coinsCollected.ToString();
    }
}
