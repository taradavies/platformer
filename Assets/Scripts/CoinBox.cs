using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : HittableFromAbove
{
    [SerializeField] int totalCoins = 3;
    [SerializeField] GameObject coinSprite;
    int remainingCoins;

    protected override bool canUse => remainingCoins > 0;

    void Start() {
        remainingCoins = totalCoins;
    }

    protected override void UseBox() {
        Coin.coinsCollected++;
        remainingCoins --;
    }

    protected override void TurnOffSprite()
    {
        base.TurnOffSprite();
        coinSprite.SetActive(false);
    }
}
