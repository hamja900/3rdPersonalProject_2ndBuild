using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public GameObject elements;
    private ItemSlot curSlot;
    Chad chad;

    public int index;

    [Header("Displayed Items")]
    public Image displayedImage;
    public Text displayedItemName;
    public Text displayedItemDesc;
    public Text displayedItemStatName;
    public Text displayedItemStatValue;
    public Text displayedItemPrice;

    private void Awake()
    {
        chad = Inventory.Instance.GetComponent<Chad>();
    }
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
        displayedItemPrice.text = curSlot.item.itemPrice.ToString();
    }

    public void OnPurchaseBtn()
    {
        AudioManager.Instance.ClickSound();
        if (chad.cash >= curSlot.item.itemPrice)
        {
            Shop.Instance.purchasePopUp.SetActive(true);
            chad.cash -= curSlot.item.itemPrice;
            Inventory.Instance.AddItem(Shop.Instance.shopItems[index]);
        }
        else
        {
            Shop.Instance.errorMessagePopUp.SetActive(true);
        }
    }
}
