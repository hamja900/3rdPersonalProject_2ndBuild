using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Chad player;

    public Slider expSlider;
    public GameObject sideMenuBtns;
    public GameObject statusWindow;
    public GameObject inventoryWindow;
    public GameObject shopWindow;
    public GameObject bankWindow;

    public Text nameText;
    public Text descriptionText;
    public Text levelText;
    public Text goldText;
    public Text currentExpText;
    public Text maxExpText;

    public Text atkText;
    public Text defText;
    public Text hpText;
    public Text critText;

    [Header("Bank")]
    public Text cash;
    public Text banlance;
    public Text userNameText;

    private Chad chad;

    private void Awake()
    {
        chad = player.GetComponent<Chad>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
 

    }

    // Update is called once per frame
    void Update()
    {
        ExPSliderSetting();
        CombatStatusSetting();
        MainUISetting();
        BankSetting();
    }

    void MainUISetting()
    {

        nameText.text = chad.PlayerName;
        descriptionText.text = chad.PlayerDesc;
        levelText.text = chad.level.ToString();
        goldText.text = chad.cash.ToString();
        currentExpText.text = chad.curExp.ToString();
        maxExpText.text = chad.maxExp.ToString();

    }
    void ExPSliderSetting()
    {

        float currentExp = chad.curExp;
        float nextExp = chad.maxExp;
        expSlider.value = currentExp / nextExp;

    }

    void BankSetting()
    {
        cash.text = chad.cash.ToString();
        banlance.text = chad.banlance.ToString();
        userNameText.text = chad.PlayerName;
    }

    void CombatStatusSetting()
    {
        atkText.text = (chad.atk+Inventory.Instance.extraAtk).ToString();
        defText.text = (chad.def+Inventory.Instance.extraDef).ToString();
        hpText.text = (chad.hp + Inventory.Instance.extraHP).ToString();
        critText.text = (chad.crit + Inventory.Instance.extraCrit).ToString();
    }

    public void OnStatusBtn()
    {
        sideMenuBtns.SetActive(false);
        statusWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }
    public void OnInventoryBtn()
    {
        sideMenuBtns.SetActive(false);
        inventoryWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }

    public void OnShopBtn()
    {
        sideMenuBtns.SetActive(false);
        shopWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }
    public void OnBankBtn()
    {
        sideMenuBtns.SetActive(false);
        bankWindow.SetActive(true);
        AudioManager.Instance.ClickSound();
    }
    public void OnBackBtn()
    {
        statusWindow.SetActive(false);
        inventoryWindow.SetActive(false);
        shopWindow.SetActive(false);
        sideMenuBtns.SetActive(true);
        bankWindow.SetActive(false);
        AudioManager.Instance.ClickSound();
    }


}
