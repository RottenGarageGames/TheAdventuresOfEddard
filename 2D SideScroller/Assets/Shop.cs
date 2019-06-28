using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : Inventory
{
    public List<GameObject> ShopSlots;
    public int ShopGold;
    public Text ShopGoldText;

    public List<ItemData> items;

    public GameObject player;

    private void Start()
    {
        var length = items.Count;

        Debug.Log(length);

        foreach(var slot in ShopSlots)
        {
            var randomItem = items[Random.Range(0, length)];
            Debug.Log(randomItem.Name.ToString());
            var cloneItem = new ItemData(randomItem);
            Debug.Log(cloneItem.Name.ToString());
            Items.Add(cloneItem);
            var slotImageId = slot.GetComponentInChildren<ImageID>();
            var slotText = slot.GetComponentInChildren<Text>();
            slot.gameObject.GetComponent<Image>().sprite = cloneItem.Sprite;
            slotImageId.itemData = cloneItem;
            slotText.text = cloneItem.Name.ToString();


            var priceText = slot.GetComponentsInChildren<Text>();

            foreach(var textComponent in priceText)
            {
                if(textComponent.name == "Price")
                {
                    textComponent.text = "Price: " + cloneItem.Price.ToString();
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
    public void ProcessTransaction(ItemData item)
    {
        if(ValidTransaction(item.Price))
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
