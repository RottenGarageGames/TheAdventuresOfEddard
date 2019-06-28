using Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour

{
    public static int Balance;
    public GameObject Player;
    public Text BalanceDisplay;
    private Currency playerCurrency;
    public string TransactionAmount;
    public InputField InputField;
    public Canvas BankInterface;
    // Start is called before the first frame update
    void Start()
    {
        BankInterface.gameObject.SetActive(false);
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
            InputField.text = "";
            ValidTransaction();
        }
        else
        {
            InvalidTransaction();
        }
        
    }
    public void Deposit()
    {
        var depositAmount = Convert.ToInt32(TransactionAmount);
        if(playerCurrency.stat >= depositAmount)
        {
            Balance += depositAmount;
            playerCurrency.stat -= depositAmount;
            InputField.text = "";
            ValidTransaction();
        }
        else
        {
            InvalidTransaction();
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
            BankInterface.gameObject.SetActive(true);
            Player = collision.gameObject;
            playerCurrency = Player.GetComponent<Currency>();

            
           
            DataManager.PlayerOneBankData = new BankData(Balance, null, CalebPlayerController.PlayerID.PlayerOne);
            Balance = DataManager.PlayerOneBankData.Balance;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == Player)
        {
            Player = null;
            BankInterface.gameObject.SetActive(false);
            ResetUi();
        }
    }
    private void InvalidTransaction()
    {
        InputField.image.color = Color.red;
        InputField.textComponent.color = Color.white;
    }
    private void ValidTransaction()
    {
        InputField.image.color = Color.white;
        InputField.textComponent.color = Color.black;
        InputField.text = "";
    }
    private void ResetUi()
    {
        InputField.image.color = Color.white;
        InputField.textComponent.color = Color.black;
        InputField.text = "";
    }
}
