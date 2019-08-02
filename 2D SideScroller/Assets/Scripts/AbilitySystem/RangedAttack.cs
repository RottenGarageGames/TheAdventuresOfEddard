using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class RangedAttack : Attack
{
    public Projectile Projectile;

    public override void OnUse(GameObject callingObject)
    {
        var p =  Instantiate(Projectile, callingObject.transform.position,Quaternion.identity);
        p.Damage = Damage;
    }
    public virtual void OnProjectileSpawn(GameObject callingObject)
    {
        
    }

}
