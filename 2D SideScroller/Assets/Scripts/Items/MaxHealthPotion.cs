using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class MaxHealthPotion : StackableItem, IConsumable
{

    public bool Consume(GameObject player)
    {
        var healthComponent = player.GetComponent<CalebPlayerController>();
        healthComponent.PlayerStats.Health = healthComponent.PlayerStats.MaxHealth;
        Destroy(gameObject);
        return true;
    }
}
