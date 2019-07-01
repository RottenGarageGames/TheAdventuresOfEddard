using Items;
using System.Collections.Generic;
using static CalebPlayerController;

public class BankData

{
    public int Balance;
    public List<Item> Items;
    public PlayerID PlayerID;
    public BankData(int balance, List<Item> items, PlayerID playerid )
    {
        Balance = balance;
        Items = items;
        PlayerID = playerid;
    }
}
