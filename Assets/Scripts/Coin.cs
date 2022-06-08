using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coinsCollected;

    [SerializeField] AudioClip[] coinAudios;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.TryGetComponent<Player>(out var player)) {
            coinsCollected++;
            ScoreSystem.AddScore(100);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            if (coinAudios.Length > 0)
                GetComponent<AudioSource>().PlayOneShot(GenerateRandomClip());
            else {
                GetComponent<AudioSource>().Play();
            }
        }
    }
    private AudioClip GenerateRandomClip()
    {
        int randomClipIndex = UnityEngine.Random.Range(0, coinAudios.Length);
        return coinAudios[randomClipIndex];
    }
}
