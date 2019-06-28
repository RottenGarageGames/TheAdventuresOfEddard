using System.Collections.Generic;
using static CalebPlayerController;

public class BankData

{
    public int Balance;
    public List<ItemData> Items;
    public PlayerID PlayerID;
    public BankData(int balance, List<ItemData> items, PlayerID playerid )
    {
        Balance = balance;
        Items = items;
        PlayerID = playerid;
    }
}
