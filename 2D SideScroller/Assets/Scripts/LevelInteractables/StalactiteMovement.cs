using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteMovement : MonoBehaviour
{
     private Rigidbody2D rigidBody;
     public float fallSpeed;
     public int damageAmount;
     public string startCollider;
     
     private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rigidBody.gravityScale = fallSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //other.SendMessage("TakeDamage", damageAmount);
        if (other.gameObject.tag != startCollider)
        {
            if(other.gameObject.tag == "Player")
            {
                var damagableObject = other.gameObject.GetComponent<IDamagable>();
                damagableObject.TakeDamage(damageAmount);
            }
            AudioManager.instance.Play("CaveSpikes");
            Destroy(gameObject);
        }

    }
    
}
