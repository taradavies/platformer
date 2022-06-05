using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{
    [SerializeField] List<Collectible> collectibles;
    [SerializeField] UnityEvent onCollectionComplete;
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
        else {
            onCollectionComplete?.Invoke();
        }
    }

    // called when a value is changed within the inspector
    void OnValidate() {
        collectibles = collectibles.Distinct().ToList();
    }
}
