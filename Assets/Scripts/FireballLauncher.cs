using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    [SerializeField] float fireRate;
    float fireTimer;
    int playerNumber;
    string fireCommand;
    void Start()
    {
        playerNumber = GetComponent<Player>().PlayerNumber;
        fireCommand = $"P{playerNumber}Fire";
    }
    void Update()
    {
        if (Input.GetButton(fireCommand)) {
            Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        }
    }
}
