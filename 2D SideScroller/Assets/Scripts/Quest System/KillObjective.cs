using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjective : Objective
{
    public string EnemyTag {get; set;}
    
    public KillObjective(string enemyTag, string description, bool completed, int currentKillAmount, int requiredAmount)
    {
        this.EnemyTag = enemyTag;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentKillAmount;
        this.RequiredAmount = requiredAmount;
    }
    public override void Init()
    {
        base.Init();
    }
    void EnemyDied(IEnemy enemy)
    {
        if(enemy.Tag == EnemyTag)
        {
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
