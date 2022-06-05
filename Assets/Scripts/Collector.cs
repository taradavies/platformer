using System;
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
    public int countCollected = 0;

    void Start() {
        remainingCollectibleText = GetComponentInChildren<TMP_Text>();
        foreach(var collectible in collectibles) {
            collectible.SetCollector(this);
        }
        remainingCollectibleText?.SetText(collectibles.Count.ToString());
    }


    public void PickUpCollectible() {
        countCollected++;

        int countRemaining = collectibles.Count - countCollected;

        remainingCollectibleText?.SetText(countRemaining.ToString());

        if (countRemaining <= 0) 
            onCollectionComplete?.Invoke();
    }

    // called when a value is changed within the inspector
    void OnValidate() {
        collectibles = collectibles.Distinct().ToList();
    }


}
