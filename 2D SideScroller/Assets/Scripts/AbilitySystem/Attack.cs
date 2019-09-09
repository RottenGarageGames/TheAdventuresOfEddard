using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : Ability
{
    public int Damage;

    public override void Use(GameObject o)
    {
        OnUse(o);
    }
    public abstract void OnUse(GameObject o);

    
}
