using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class HealthPotion : StackableItem, IConsumable
{
    public int healAmount;

   public bool Consume(GameObject player)
    {
        var playerController = player.GetComponent<CalebPlayerController>();
        var currentHealth = playerController.Health;
        var maxHealth = playerController.MaxHealth;
        if (currentHealth + healAmount <= maxHealth)
        {
            currentHealth += healAmount;
            Destroy(gameObject);
            return true;
        }
        else if(currentHealth == maxHealth)
        {
            Debug.Log("health is full");
            return false;
        }
        else
        {
            currentHealth = maxHealth;
            Destroy(gameObject);
            return true;
        }
        
    }
}
