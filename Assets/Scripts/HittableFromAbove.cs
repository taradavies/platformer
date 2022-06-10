using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HittableFromAbove : MonoBehaviour
{
    [SerializeField] protected Sprite usedSprite;
    Animator controller;
    AudioSource audioSource;
    protected virtual bool canUse => true;

    void Awake() {
        controller = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (!canUse) {return;}
        
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Vector2 collisionNormal = collision.GetContact(0).normal; 
            if (collisionNormal.y > 0 && canUse) {
                PlayAudio();
                PlayAnimation();
                Use();
                if (!canUse) {
                    TurnOffSprite();
                }
            }
        } 
    }

     void PlayAudio()
    {
        if (audioSource != null) 
            audioSource.Play();
    }

    protected virtual void TurnOffSprite()
    {
        GetComponent<SpriteRenderer>().sprite = usedSprite;
    }

    private void PlayAnimation()
    {
        if (controller != null)
            controller.SetTrigger("Use");
    }

    // virtual allows the method to be overriden
    // abstract makes each child class implement this method
    protected abstract void Use();
}
