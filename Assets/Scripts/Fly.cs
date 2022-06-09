using UnityEngine;

public class Fly : MonoBehaviour, ITakeHit
{
    [SerializeField] float maxHeight = 2f;
    [SerializeField] Vector2 direction = Vector2.up;
    [SerializeField] float moveSpeed = 3f;
    Vector2 startingPos;

    public void TakeDamage()
    {
        Destroy(gameObject);
    }

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
}
