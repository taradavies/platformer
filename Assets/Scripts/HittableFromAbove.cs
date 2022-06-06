using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableFromAbove : MonoBehaviour
{
    [SerializeField] protected Sprite usedSprite;
    Animator controller;
    protected virtual bool canUse => true;

    void Awake() {
        controller = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (!canUse) {return;}
        
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Vector2 collisionNormal = collision.GetContact(0).normal; 
            if (collisionNormal.y < 0 && canUse) {
                PlayAnimation();
                UseBox();
                if (!canUse) {
                    TurnOffSprite();
                }
            }
        } 
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
    protected virtual void UseBox() {
        //Debug.Log($"Used {gameObject.name}");
    }
}
