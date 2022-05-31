using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float maxHeight = 2f;
    Vector2 startingPos;
    Vector2 direction = Vector2.up;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
        var distance = Vector2.Distance(startingPos, transform.position);
        
        if (distance >= maxHeight) 
            direction *= -1;
        
    }
}
