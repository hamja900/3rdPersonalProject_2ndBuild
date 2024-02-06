using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public GameObject bankMainBtns;
    public GameObject depositWindow;

    [Header("MainMenu")]
    public GameObject depositBtn;
    public GameObject withdrawBtn;

    [Header("depositMenu")]
    public InputField inputfield;
    
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
    
}
