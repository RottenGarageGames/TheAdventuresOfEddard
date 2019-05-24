using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Stat
{
    public int CurrentXp;
    public int XpToNextLevel;
    
    public void CheckForLevelUp()
    {
        if (CurrentXp >= XpToNextLevel)
        {
            IncreaseStat(1);
        }

        IncreaseXpToNextLevel();
    }
    public void IncreaseXpToNextLevel()
    {
        XpToNextLevel = (int)(60 * System.Math.Sqrt(CurrentXp) - 60);
    }
}
