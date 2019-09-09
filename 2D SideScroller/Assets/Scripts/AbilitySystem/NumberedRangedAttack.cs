using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Attacks/Numbered Ranged Attack", fileName = "NewProjectile.asset")]
public class NumberedRangedAttack : RangedAttack
{
    public override void OnProjectileSpawn(GameObject callingObject)
    {
        //Implement Decrementation
        base.OnProjectileSpawn(callingObject);
    }
}
