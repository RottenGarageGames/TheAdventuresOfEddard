using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour

{
    public int Balance;
    public GameObject Player;
    public Text BalanceDisplay;
    private Currency playerCurrency;
    public string TransactionAmount;
    public InputField InputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BalanceDisplay.text = Balance.ToString();
    }
    public void Withdrawal()

    {
        var withdrawalAmount = Convert.ToInt32(TransactionAmount);
        if (Balance >= withdrawalAmount)
        {
            Balance -= withdrawalAmount;
            playerCurrency.stat += withdrawalAmount;
        }
    }
    public void Deposit()
    {
        var depositAmount = Convert.ToInt32(TransactionAmount);
        if(playerCurrency.stat >= depositAmount)
        {
            Balance += depositAmount;
            playerCurrency.stat -= depositAmount;
        }
       

    }
    public void UpdateTransactionAmount()
    {
        TransactionAmount = InputField.text;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Player == null)
        {
   
            Player = collision.gameObject;
            playerCurrency = Player.GetComponent<Currency>();
            Balance = playerCurrency.stat;

            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Player = null;
        }
    }



}
