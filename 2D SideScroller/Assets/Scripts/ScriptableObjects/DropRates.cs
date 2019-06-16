using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Items/Drop Rate", fileName = "DropRateName.asset")]
public class DropRates : ScriptableObject
{
    public float CurrencyDropRate;
    public float CommonDropRate;
    public float UncommonDropRate;
    public float RareDropRate;
    public float EpicDropRate;
    public float MultipleItemDropRate;
}
