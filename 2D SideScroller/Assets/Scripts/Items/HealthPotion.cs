using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class HealthPotion : StackableItem, IConsumable
{
    public int healAmount;

   public void Consume(GameObject player)
    {
        var healthComponent = player.GetComponent<PlayerHealth>();
        healthComponent.RestoreHealth(healAmount);
        Destroy(gameObject);
    }
}
