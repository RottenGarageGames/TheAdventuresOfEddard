using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : Stat
{

    private void Update()
    {
        if(!currencyText.text.Equals(stat.ToString()))
        {
            SetUICurrencyText();
        }
    }
    public Text currencyText;

    public bool HasEnoughCurrency(int amount)
    {
        if (stat > amount)
        {
            return true;
        }
        return false;
    }
    public void SetUICurrencyText()
    {
        currencyText.text = stat.ToString();
    }
}
