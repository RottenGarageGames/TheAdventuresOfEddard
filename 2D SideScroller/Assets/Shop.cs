using Items;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityInterfaces;

public class Shop : Inventory
{
    public List<GameObject> ShopSlots;
    public List<Item> items;
    public int ShopGold;
    public Text ShopGoldText;

    public GameObject player;

    private void Start()
    {
        var listOfObjects = Resources.LoadAll("Items/Potions/", typeof(GameObject));

        var length = listOfObjects.Length;
        items = new List<Item>();


        Debug.Log(length);

        foreach(var slot in ShopSlots)
        {
            var testItem = listOfObjects[Random.Range(0, length)] as GameObject;
            var itemInfo = testItem.GetComponent<Item>();
            items.Add(itemInfo);
            var slotImageId = slot.GetComponentInChildren<ImageID>();
            var slotText = slot.GetComponentInChildren<Text>();
            slot.gameObject.GetComponent<Image>().sprite = testItem.GetComponent<SpriteRenderer>().sprite;
            slotImageId.itemID = itemInfo.OnStartItemID;
            slotText.text = itemInfo.OnStartItemName.ToString();


            var priceText = slot.GetComponentsInChildren<Text>();

            foreach(var textComponent in priceText)
            {
                if(textComponent.name == "Price")
                {
                    textComponent.text = "Price: " + itemInfo.OnStartBasePrice.ToString();
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
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ProcessTransaction(Item item)
    {
        if(ValidTransaction(item.basePrice))
        {
            //Need to load item
            player.GetComponent<PlayerInventory>().AddItem(item);
        }
    }
    public void IncreaseShopGold(int amount)
    {
        ShopGold += amount;
    }
}
