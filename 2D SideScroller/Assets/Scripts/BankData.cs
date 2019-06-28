using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CalebPlayerController;

public class BankData

{
    public int Balance;
    public ItemList Items;
    public PlayerID PlayerID;
    public BankData(int balance, ItemList items, PlayerID playerid )
    {
        Balance = balance;
        Items = items;
        PlayerID = playerid;
        
    }




}
