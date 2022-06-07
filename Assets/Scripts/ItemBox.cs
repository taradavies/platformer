using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : HittableFromAbove
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] float itemLaunchVelocity;
    GameObject item;
    bool usedItem = false;

    protected override bool canUse => !usedItem && itemPrefab != null;
    protected override void UseBox()
    {
        item = Instantiate(
            itemPrefab, 
            transform.position + Vector3.up, 
            Quaternion.identity,
            transform);
            
        usedItem = true;
        var itemRb = item.GetComponent<Rigidbody2D>();
        if (itemRb != null && !usedItem) {
            Launch(itemRb);
        }
    }
    void Launch(Rigidbody2D itemRb) {
        itemRb.velocity = new Vector2(itemRb.velocity.x, itemLaunchVelocity);
    }

    protected override void TurnOffSprite()
    {
        base.TurnOffSprite();
    }

}