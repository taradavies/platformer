using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public event Action OnPickedUp;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            gameObject.SetActive(false);

            OnPickedUp?.Invoke();
        }
    }
}