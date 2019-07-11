using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopImageID : ImageID
{
    public Shop shop;

    public void BuyItem()
    {
        shop.ProcessTransaction(itemData);
        Debug.Log("Buy Item");
    }
}
