using UnityEngine;

namespace Items
{
    public class HealthPotion : Item
    {
        public int HealPoints = 50;

        public override void Use(GameObject player)
        {
            var health = player.GetComponent<CalebPlayerController>();

            health.PlayerStats.AddHealth(HealPoints);
        }
    }
}