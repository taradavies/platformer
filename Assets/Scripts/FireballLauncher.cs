using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball fireballPrefab;
    [SerializeField] float fireDelay;
    int playerNumber;
    string fireCommand;
    string playerHorizontalCommand;
    float nextFireTime;

    void Awake()
    {
        playerNumber = GetComponent<Player>().PlayerNumber;
        fireCommand = $"P{playerNumber}Fire";
        playerHorizontalCommand = $"P{playerNumber}Horizontal";
    }
    void Update()
    {
        if (Input.GetButton(fireCommand) && Time.time >= nextFireTime) {

            var playerHorizontalInput = Input.GetAxis(playerHorizontalCommand);
            int currentPlayerDirection = playerHorizontalInput >= 0 ? 1 : -1;

            Fireball fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            fireball.Direction = currentPlayerDirection;
            
            nextFireTime = Time.time + fireDelay;
        }
    }
}
