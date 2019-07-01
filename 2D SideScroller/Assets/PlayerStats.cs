using System;

[Serializable]
public class PlayerStats
{
    public int Health = 5;
    public int MaxHealth = 5;

    public int Stamina;
    public int MaxStamina;

    public int AddHealth(int healPoints)
    {
        var pointsHealed = healPoints;

        if(Health + healPoints > MaxHealth)
        {
            pointsHealed = MaxHealth - Health;
            Health = MaxHealth;
        }
        else
        {
            Health += healPoints;
        }

        return pointsHealed;
    }
}
