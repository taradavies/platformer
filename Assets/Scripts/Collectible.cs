using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    Collector collector;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            gameObject.SetActive(false);
            collector.PickUpCollectible();
        }
    }

    public void SetCollector(Collector collector) {
        this.collector = collector;
    }
}