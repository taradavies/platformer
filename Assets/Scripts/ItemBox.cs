using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Sprite usedItemBox;
    [SerializeField] GameObject itemSpawned;
    [SerializeField] float itemLaunchVelocity;
    bool usedItem = false;

    void Start() {
        itemSpawned.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player)) 
        {  
            Vector2 normal = collision.GetContact(0).normal;
            // If we hit the object from above increment the coins collected
            if (normal.y < 0) 
            {  
                usedItem = true; 
                GetComponent<SpriteRenderer>().sprite = usedItemBox;
                itemSpawned.SetActive(true);
                var itemRb = itemSpawned.GetComponent<Rigidbody2D>();
                if (itemRb != null && !usedItem) {
                    Launch(itemRb);
                    usedItem = false;
                }
            }
        }
    }
    void Launch(Rigidbody2D itemRb) {
        itemRb.velocity = new Vector2(itemRb.velocity.x, itemLaunchVelocity);
    }

}