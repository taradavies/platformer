using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] collectibles;


    void Update() {
        // if any items are still active
        if (collectibles.Any(t => t.gameObject.activeSelf))
            return;
        
        //Debug.Log("All gems are gone!");
    }


}
