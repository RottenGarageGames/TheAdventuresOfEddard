using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUP : MonoBehaviour
{
    public string Name { get; set; }
    public TimeSpan Duration { get; set; }
    private Rigidbody2D powerUp;
   
    // Start is called before the first frame update
    void Start()
    {
        powerUp = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
