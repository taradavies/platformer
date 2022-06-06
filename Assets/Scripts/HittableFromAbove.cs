using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableFromAbove : MonoBehaviour
{
    [SerializeField] protected Sprite usedSprite;
    protected virtual bool canUse => true;

    void OnCollisionEnter2D(Collision2D collision) {

        if (!canUse) {return;}
        
        if (collision.gameObject.TryGetComponent<Player>(out var player)) {
            Vector2 collisionNormal = collision.GetContact(0).normal; 
            if (collisionNormal.y < 0 && canUse) {
                UseBox();
                if (!canUse) {
                    GetComponent<SpriteRenderer>().sprite = usedSprite;
                }
            }
        } 
    }

    // virtual allows the method to be overriden
    protected virtual void UseBox() {
        //Debug.Log($"Used {gameObject.name}");
    }
}
