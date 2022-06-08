using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinsCollected;

    [SerializeField] AudioClip[] coinAudios;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            coinsCollected++;
            ScoreSystem.AddScore(100);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(GenerateRandomClip());
        }
    }
    private AudioClip GenerateRandomClip()
    {
        int randomClipIndex = UnityEngine.Random.Range(0, coinAudios.Length);
        return coinAudios[randomClipIndex];
    }
}
