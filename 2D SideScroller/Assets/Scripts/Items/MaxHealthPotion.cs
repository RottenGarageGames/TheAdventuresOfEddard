using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class MaxHealthPotion : StackableItem, IConsumable
{

    public bool Consume(GameObject player)
    {
        var playerController = player.GetComponent<CalebPlayerController>();
        if (playerController.Health < playerController.MaxHealth)
        {
            playerController.Health = playerController.MaxHealth;
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
