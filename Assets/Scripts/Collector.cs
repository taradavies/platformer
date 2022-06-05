using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] collectibles;
    TMP_Text remainingCollectibleText;

    void Start() {
        remainingCollectibleText = GetComponentInChildren<TMP_Text>();
    }


    void Update() {
        int countRemaining = 0;
        
        foreach(var collectible in collectibles) {
            if (collectible.isActiveAndEnabled) {
                countRemaining++;
            }
        }
        
        // if its not null --> '?'
        remainingCollectibleText?.SetText(countRemaining.ToString());

        if (countRemaining > 0) {return;}
    }


}
