using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInterfaces;

public class Coin : Stat
{
    private bool _beingPickedUp = false;

    public void AddToPurse(GameObject player)
    {
        var purse = player.GetComponent<Currency>();
  
        if (purse != null && !_beingPickedUp)
        {
            _beingPickedUp = true;
            purse.IncreaseStat(stat);
            Destroy(gameObject);
        }
    }
    public void SetBeingPickedUp()
    {
        _beingPickedUp = true;
    }
    public void RemoveBeingPickedUp()
    {
        _beingPickedUp = false;
    }
    public bool ReturnBeingPickedUp()
    {
        return _beingPickedUp;
    }
}
