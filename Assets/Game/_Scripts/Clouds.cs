using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField] float velocity = 0.2f;
    
    void FixedUpdate()
    {
    
        Vector3 newPosition = gameObject.transform.position;
        newPosition.x += velocity * Time.deltaTime;
        gameObject.transform.position = newPosition;

        if(gameObject.transform.position.x > 42f){
            gameObject.transform.position = new Vector3(-42f, 1.5f, 1400);
        }
    
    }
}
