using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    List<Collector> collectors = new List<Collector>();
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            gameObject.SetActive(false);

            foreach (var collector in collectors) {
                collector.PickUpCollectible();
            }
        }
    }

    public void SetCollector(Collector collector) {
        collectors.Add(collector);
    }
}