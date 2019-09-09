using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public int stat;
    public int maxStat;


    public void IncreaseStat(int amount)
    {
        stat += amount;
    }
    public bool DecreaseStat(int amount)
    {
        if (stat - amount >= 0)
        {
            stat -= amount;
            return true;
        }

        return false;
    }
    public void SetStatToZero()
    {
        stat = 0;
    }
    public void IncreaseMaxStat(int increaseAmount)
    {
        maxStat += increaseAmount;
    }
    public void DecreaseMaxStat(int decreaseAmount)
    {
        maxStat -= decreaseAmount;
    }
}
