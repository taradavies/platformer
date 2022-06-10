using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : HittableFromAbove
{
    [SerializeField] float fadeTime = 2f;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
    }
    protected override void Use()
    {
        spriteRenderer.enabled = false;
        collider2d.enabled = false;

        StartCoroutine(ResetAfterFadeDelay());
    }

    IEnumerator ResetAfterFadeDelay() {
        yield return new WaitForSeconds(fadeTime);
        spriteRenderer.enabled = true;
        collider2d.enabled = true;
    }
}
