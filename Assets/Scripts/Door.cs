using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite doorTop;
    [SerializeField] Sprite doorMid;
    [SerializeField] SpriteRenderer doorTopRenderer;
    [SerializeField] SpriteRenderer doorMidRenderer;

    [ContextMenu("Open Door")]
    void Open() {
        doorTopRenderer.sprite = doorTop;
        doorMidRenderer.sprite = doorMid;
    }
    
}
