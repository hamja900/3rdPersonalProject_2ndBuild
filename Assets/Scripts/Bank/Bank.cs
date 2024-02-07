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
    public GameObject withDrawWindow;

    [Header("MainMenu")]
    public GameObject depositBtn;
    public GameObject withdrawBtn;

    [Header("inputField")]
    public InputField inputfield;

    [Header("PopUps")]
    public GameObject noMoney;
    public GameObject noInput;
    public GameObject noBanlance;

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
    public void OnWithDrawBtn()
    {
        bankMainBtns.SetActive(false);
        withDrawWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }

    public void OnBankBackBtn()
    {
        depositWindow.SetActive(false);
        withDrawWindow.SetActive(false);
        bankMainBtns.SetActive(true);
        AudioManager.Instance.ClickSound();
    }

    public void OnDpstTenK()
    {
        if (chad.cash >= 10000)
        {
            chad.cash -= 10000;
            chad.banlance += 10000;
        }
        else
        {
            noMoney.SetActive(true);
        }
    }
    public void OnDpstTirtyK()
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
    public void OnDpstFiftyK()
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
            else if (chad.cash < int.Parse(inputfield.text))
            {
                noMoney.SetActive(true);
            }
        }
        catch
        {
            noInput.SetActive(true);

        }


    }
    public void OnWdrTenK()
    {
        if (chad.banlance >= 10000)
        {
            chad.banlance -= 10000;
            chad.cash += 10000;
        }
        else
        {
            noBanlance.SetActive(true);
        }
    }
    public void OnWdrTirtyK()
    {
        if (chad.banlance >= 30000)
        {
            chad.banlance -= 30000;
            chad.cash += 30000;
        }
        else
        {
            noBanlance.SetActive(true);
        }
    }
    public void OnWdrFiftyK()
    {
        if (chad.banlance >= 50000)
        {
            chad.banlance -= 50000;
            chad.cash += 50000;
        }
        else
        {
            noBanlance.SetActive(true);
        }
    }

    public void OnInputWithDraw()
    {
        try
        {
            if (chad.banlance >= int.Parse(inputfield.text))
            {
                chad.banlance -= int.Parse(inputfield.text);
                chad.cash += int.Parse(inputfield.text);
            }
            else if (chad.banlance < int.Parse(inputfield.text))
            {
                noBanlance.SetActive(true);
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
        noBanlance.SetActive(false);
        AudioManager.Instance.ClickSound();
    }
}
