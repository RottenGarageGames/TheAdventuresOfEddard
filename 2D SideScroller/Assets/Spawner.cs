using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ScriptableObject
{    
   //Takes a scriptable object and spawns it
    public static void SpawnItem(ItemData data, Vector3 spawnPos)
    {
        Instantiate(data.Prefab, spawnPos, Quaternion.identity);
    }

    public static void SpawnRandomItem(List<ItemData> items, Vector3 spawnPos)
    {
        var length = items.Count;
        var itemToSpawn = items[Random.Range(0, length)];
        Instantiate(itemToSpawn.Prefab, spawnPos, Quaternion.identity);
    }

    //Will take an object of type MonsterData
    public static void SpawnMonster()
    {

    }
}
