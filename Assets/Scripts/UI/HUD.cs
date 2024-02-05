using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Chad player;

    public Image expFrontBar;

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

    // Start is called before the first frame update
    void Start()
    {
        MainUISetting();
        expFrontBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainUISetting()
    {
        Chad chad = player.GetComponent<Chad>();
        nameText.text = chad.PlayerName;
        descriptionText.text = chad.PlayerDesc;
        levelText.text = chad.level.ToString();
        goldText.text = chad.gold.ToString();
        currentExpText.text = chad.curExp.ToString();
        maxExpText.text = chad.maxExp.ToString();

        expFrontBar.fillAmount = chad.curExp / chad.maxExp;
    }
}
