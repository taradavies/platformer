using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Collider2D))]
public class Collectible : MonoBehaviour
{
    public event Action OnPickedUp;
    AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            OnPickedUp?.Invoke();
            audioSource.Play();
        }
    }
}