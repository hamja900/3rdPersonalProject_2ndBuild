using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Chad player;

    public Slider expSlider;

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


}
