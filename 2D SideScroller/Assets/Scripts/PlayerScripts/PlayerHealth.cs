using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Sprite healthIcon;
    public Sprite shieldIcon;

    public int health;
    public int shieldHealth;
    public int maxHealth;
    public int maxShield;
    public List<GameObject> healthIcons;
    public Canvas playerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerCanvas = gameObject.GetComponent<Canvas>();
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
          Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        //Calculate the leftover damage to apply to health
        var leftoverDamage = damage - shieldHealth;

        //Damage Shields first
        if (shieldHealth > 0)
        {
            shieldHealth -= damage;
        }
        //If shield doesn't cover damage apply to health
        if(leftoverDamage > 0)
        {
            health -= damage;
        }

        UpdateIcons();
    }
    public void RestoreHealth(int restoreAmount)
    {
        if (health < maxHealth)
        {
            health += restoreAmount;

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
        health = maxHealth;

        foreach (GameObject healthIcon in healthIcons)
        {
            healthIcon.SetActive(true);
        }
    }
    public void AddShield(int shieldAmount)
    {
        shieldHealth += shieldAmount;
        UpdateIcons();
    }
    public void MaxShield()
    {
        shieldHealth = maxShield;
        UpdateIcons();
    }
    public void UpdateIcons()
    {
        var count = 1;

        foreach (GameObject slot in healthIcons)
        {


            if(count <= shieldHealth)
            {
                slot.GetComponent<Image>().sprite = shieldIcon;
            }
            else if(count <= health)
            {
                slot.GetComponent<Image>().sprite = healthIcon;
            }
            else
            {
               slot.SetActive(false);
            }

            count++;
        }
    }
}
