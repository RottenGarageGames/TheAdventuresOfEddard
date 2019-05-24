using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{

    public float health;
    public float level;
    private bool inRange = false;
    public bool collidingWithPlayer = false;
    private int meleeDamage;




    public GameObject enemyHealthBar;
    public bool hasBossHealthBar;
    private Slider slider;
    public GameObject bloodEffect;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (hasBossHealthBar)
        {
            slider = enemyHealthBar.GetComponent<Slider>();
            slider.maxValue = health;
            slider.value = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if (bloodEffect != null)
            {
                Instantiate(bloodEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            Destroy(gameObject);
            
        }
    }
    void OnCollisionEnter2D(Collider2D other)
    {
            Debug.Log("Enemy: Collided with the Player"); 
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (slider != null)
        {
            slider.value = health;
        }
        
        
    }
    public void TogglePlayerInRange()
    {
        if (collidingWithPlayer)
        {
            inRange = !inRange;
            if (inRange)
            {
                if (enemyHealthBar != null)
                {
                    enemyHealthBar.SetActive(true);
                }
            }
            else
            {
                if (enemyHealthBar != null)
                {
                    enemyHealthBar.SetActive(false);
                }
            }
        }
    }

}
