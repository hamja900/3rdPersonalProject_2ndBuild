using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Image image;
    public GameObject elements;
    private ItemSlot curSlot;

    public int index;

    [Header("Displayed Items")]
    public Image displayedImage;
    public Text displayedItemName;
    public Text displayedItemDesc;
    public Text displayedItemStatName;
    public Text displayedItemStatValue;
    public Text displayedItemPrice;


    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        elements.SetActive(true);
        ShopItemDisplay();
    }
    public void Clear()
    {
        curSlot = null;
        image.gameObject.SetActive(false);
    }

    void ShopItemDisplay()
    {
        displayedImage.sprite = curSlot.item.sprite;
        image.gameObject.SetActive(true);
        displayedItemName.text = curSlot.item.itemName;
        displayedItemDesc.text = curSlot.item.ItemDesc;
        displayedItemStatName.text = curSlot.item.equipables.type.ToString();
        displayedItemStatValue.text = curSlot.item.equipables.value.ToString();
    }

    public void OnBtnClick()
    {
       
    }
}
