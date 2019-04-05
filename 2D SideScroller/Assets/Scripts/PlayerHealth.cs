using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth;
    public List<GameObject> healthIcons;
    public Canvas playerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerCanvas = gameObject.GetComponent<Canvas>();
        maxHealth = playerHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        //Could also call change sprite here instead if we'd rather replace with another colored sprite
        healthIcons[playerHealth].SetActive(false);
    }
    public void RestoreHealth(int health)
    {
        if (playerHealth < maxHealth)
        {
            playerHealth += health;
            
            foreach (GameObject healthIcon in healthIcons)
            {
                if (!healthIcon.activeSelf)
                {
                    healthIcon.SetActive(true);
                    break;
                }
            }
        }

    }
    public void MaxOutHealth()
    {
        playerHealth = maxHealth;

        foreach(GameObject healthIcon in healthIcons)
        {
            healthIcon.SetActive(true);
        }
    }
}
