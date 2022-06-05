using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] collectibles;


    void Update() {
        // if any items are still active
        foreach(var collectible in collectibles) {
            if (collectible.isActiveAndEnabled) {
                return;
            }
        }
        // if (collectibles.Any(t => t.gameObject.activeSelf))
        //     return;
    }


}
