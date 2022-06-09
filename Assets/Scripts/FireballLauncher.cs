using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    void Start()
    {
        Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    }
    void Update()
    {
        
    }
}
