using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public GameObject player;
    Chad chad;
    

    public GameObject bankMainBtns;
    public GameObject depositWindow;

    [Header("MainMenu")]
    public GameObject depositBtn;
    public GameObject withdrawBtn;

    [Header("depositMenu")]
    public InputField inputfield;
   
    [Header("PopUps")]
    public GameObject noMoney;
    public GameObject noInput;

    private void Awake()
    {
        chad = player.GetComponent<Chad>();
    }
    public void OnDepositBtn()
    {
        bankMainBtns.SetActive(false);
        depositWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }

    public void OnBankBackBtn()
    {
        depositWindow.SetActive(false);
        bankMainBtns.SetActive(true);
        AudioManager.Instance.ClickSound();
    }

    public void OnTenK()
    {
        if(chad.cash >= 10000)
        {
            chad.cash -= 10000;
            chad.banlance += 10000;
        }
        else
        {
            noMoney.SetActive(true);
        }
    }
    public void OnTirtyK()
    {
        if (chad.cash >= 30000)
        {
            chad.cash -= 30000;
            chad.banlance += 30000;
        }
        else
        {
            noMoney.SetActive(true);
        }
    }
    public void OnFiftyK()
    {
        if (chad.cash >= 50000)
        {
            chad.cash -= 50000;
            chad.banlance += 50000;
        }
        else
        {
            noMoney.SetActive(true);
        }
    }

    public void OnInputDeposit()
    {
        try
        {
            if (chad.cash >= int.Parse(inputfield.text))
            {
                chad.cash -= int.Parse(inputfield.text);
                chad.banlance += int.Parse(inputfield.text);
            }
            else if ( chad.cash < int.Parse(inputfield.text))
            {
                noMoney.SetActive(true);
            }
        }
        catch
        {
                noInput.SetActive(true);
  
        }
        
      
    }

    public void BankConfirmBtn()
    {
        noMoney.SetActive(false);
        noInput.SetActive(false);
        AudioManager.Instance.ClickSound();
    }
}
