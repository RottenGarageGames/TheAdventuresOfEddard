using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/Drop Rate", fileName = "DropRateName.asset")]
public class DropRates : ScriptableObject
{
    public float CommonDropRate;
    public float UncommonDropRate;
    public float RareDropRate;
    public float EpicDropRate;

    public bool ChanceForMultipleItems;
    public float OneItemDropRate;
    public float TwoItemDropRate;
    public float ThreeItemDropRate;
    public float FourItemDromRate;

    public bool ChanceForCurrencyDrop;
    public float CurrencyDropChance;
}
