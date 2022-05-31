using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float maxHeight = 2f;
    [SerializeField] Vector2 direction = Vector2.up;
    [SerializeField] float moveSpeed = 3f;
    Vector2 startingPos;
    

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        transform.Translate(direction.normalized * Time.deltaTime * moveSpeed);
        var distance = Vector2.Distance(startingPos, transform.position);
        
        if (distance >= maxHeight)  {
            transform.position = startingPos + (direction.normalized * maxHeight);
            direction *= -1; 
        }
            
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.TryGetComponent<Player>(out var player)) {
            player.ResetToStart();
        }
    }

}
