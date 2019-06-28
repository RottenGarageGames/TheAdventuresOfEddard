using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ScriptableObject
{
    ItemList GlobalItemList;
    ItemList PotionList;
    ItemList PowerUpList;
    ItemList CurrencyList;
    

   //Takes a scriptable object and spawns it
    public static void SpawnItem(ItemData data, Vector3 spawnPos)
    {
        Instantiate(data.Prefab, spawnPos, Quaternion.identity);
    }
    public static void SpawnRandomItem(ItemList itemList, Vector3 spawnPos)
    {
        var length = itemList.itemDatas.Count;
        var itemToSpawn = itemList.itemDatas[Random.Range(0, length)];
        Instantiate(itemToSpawn.Prefab, spawnPos, Quaternion.identity);
    }
    public static void SpawnRandomItem(ItemList itemList, Vector3 spawnPos, DropRates dropRate)
    {

    }
    //Will take an object of type MonsterData
    public static void SpawnMonster()
    {

    }

}
