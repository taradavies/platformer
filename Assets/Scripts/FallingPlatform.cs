using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    HashSet<Player> playersOnPlatform = new HashSet<Player>();
    public bool isPlayerOnPlatform;
    Vector3 initialPosition;

    [Header("X Offset")]
    [SerializeField] float minWiggleXOffset;
    [SerializeField] float maxWiggleXOffset;

    [Header("Y Offset")]
    [SerializeField] float minWiggleYOffset;
    [SerializeField] float maxWiggleYOffset;

    void Start() {
        initialPosition = transform.position;
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            playersOnPlatform.Add(player);
            isPlayerOnPlatform = true;

            if(playersOnPlatform.Count == 1)
                StartCoroutine(WiggleAndFall());
        }
    }

    IEnumerator WiggleAndFall()
    {
        Debug.Log("Waiting to wiggle.");
        yield return new WaitForSeconds(0.25f);

        Debug.Log("Wiggling");
        float wiggleTimer = 0f;

        while (wiggleTimer < 1f) {
            Wiggle();
            float randomDelay = UnityEngine.Random.Range(0.05f, 0.01f);
            yield return new WaitForSeconds(randomDelay);
            wiggleTimer += randomDelay;
        }

        Debug.Log("Falling");
        yield return new WaitForSeconds(3f);
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {

            playersOnPlatform.Remove(player);

            if (playersOnPlatform.Count == 0) {
                isPlayerOnPlatform = false;
                StopCoroutine(WiggleAndFall());
            }
        }
    }

    private void Wiggle()
    {
        float randomXPos = UnityEngine.Random.Range(minWiggleXOffset, maxWiggleXOffset);
        float randomYPos =  UnityEngine.Random.Range(minWiggleYOffset, maxWiggleYOffset);
        Vector3 offSet = new Vector3(randomXPos, randomYPos);
        transform.position = initialPosition + offSet;
        
    }
}
