﻿using Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityInterfaces;

public class Shop : Inventory
{
    public List<GameObject> ShopSlots;
    public int ShopGold;
    public Text ShopGoldText;

    public ItemList itemDatabase;

    public GameObject player;

    private void Start()
    {


        var length = itemDatabase.itemDatas.Count;

        Debug.Log(length);

        foreach(var slot in ShopSlots)
        {
            var testItem = itemDatabase.itemDatas[Random.Range(0, length)];
            Debug.Log(testItem);
            Items.Add(testItem);
            var slotImageId = slot.GetComponentInChildren<ImageID>();
            var slotText = slot.GetComponentInChildren<Text>();
            slot.gameObject.GetComponent<Image>().sprite = testItem.sprite;
            slotImageId.itemID = testItem.itemID;
            slotText.text = testItem.itemName.ToString();


            var priceText = slot.GetComponentsInChildren<Text>();

            foreach(var textComponent in priceText)
            {
                if(textComponent.name == "Price")
                {
                    textComponent.text = "Price: " + testItem.basePrice.ToString();
                }
            }
        }
    }
    private void Update()
    {
        ShopGoldText.text = ShopGold.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }
    public bool ValidTransaction(int itemCost)
    {
        if(player.GetComponent<Currency>().stat >= itemCost)
        {
            player.GetComponent<Currency>().DecreaseStat(itemCost);
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ProcessTransaction(int itemID)
    {
        var item = Items.FirstOrDefault(x => x.itemID == itemID);
        if(ValidTransaction(item.basePrice))
        {
            //Need to load item
           player.GetComponent<PlayerInventory>().AddItem(item);
        }
        else
        {
            Debug.Log("Not enough funds.");
        }
    }
    public void IncreaseShopGold(int amount)
    {
        ShopGold += amount;
    }
}