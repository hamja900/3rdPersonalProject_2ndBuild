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

    private Chad chad;

    private void Awake()
    {
        chad = player.GetComponent<Chad>();
    }
    // Start is called before the first frame update
    void Start()
    {
        MainUISetting();
 

    }

    // Update is called once per frame
    void Update()
    {
        ExPSliderSetting();
        CombatStatusSetting();
    }

    void MainUISetting()
    {

        nameText.text = chad.PlayerName;
        descriptionText.text = chad.PlayerDesc;
        levelText.text = chad.level.ToString();
        goldText.text = chad.gold.ToString();
        currentExpText.text = chad.curExp.ToString();
        maxExpText.text = chad.maxExp.ToString();

    }
    void ExPSliderSetting()
    {

        float currentExp = chad.curExp;
        float nextExp = chad.maxExp;
        expSlider.value = currentExp / nextExp;

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
    }
    public void OnInventoryBtn()
    {
        sideMenuBtns.SetActive(false);
        inventoryWindow.SetActive(true);
    }

    public void OnShopBtn()
    {
        sideMenuBtns.SetActive(false);
        shopWindow.SetActive(true);
    }
    public void OnBackBtn()
    {
        statusWindow.SetActive(false);
        inventoryWindow.SetActive(false);
        sideMenuBtns.SetActive(true);
    }


}
