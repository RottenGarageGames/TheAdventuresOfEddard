using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class MaxHealthPotion : StackableItem, IConsumable
{

    public bool Consume(GameObject player)
    {
        var healthComponent = player.GetComponent<CalebPlayerController>().PlayerStats;
        if (healthComponent.Health < healthComponent.MaxHealth)
        {
            healthComponent.Health = healthComponent.MaxHealth;
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
