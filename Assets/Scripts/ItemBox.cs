using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : HittableFromAbove
{
    [SerializeField] GameObject itemSpawned;
    [SerializeField] float itemLaunchVelocity;
    bool usedItem = false;

    protected override bool canUse => !usedItem && itemSpawned != null;

    void Start() {
        itemSpawned.SetActive(false);
    }
    protected override void UseBox()
    {
        usedItem = true;
        itemSpawned.SetActive(true);
        var itemRb = itemSpawned.GetComponent<Rigidbody2D>();
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