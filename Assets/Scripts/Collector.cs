using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] List<Collectible> collectibles;
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

        remainingCollectibleText?.SetText(countRemaining.ToString());

        if (countRemaining > 0) {return;}
    }

    // called when a value is changed within the inspector
    void OnValidate() {
        collectibles = collectibles.Distinct().ToList();
    }


}
