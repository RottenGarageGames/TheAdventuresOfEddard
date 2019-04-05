using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class MaxShieldPotion : StackableItem, IConsumable
{
    public void Consume(GameObject player)
    {
        var healthComponent = player.GetComponent<PlayerHealth>();
        healthComponent.MaxShield();
    }
}
