using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected int startingHealth = 100;

    private int health;
    // Start is called before the first frame update
    private void Awake()
    {
        health = startingHealth;
    }

    // Update is called once per frame
   public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Destroy(gameObject);
    }
}
