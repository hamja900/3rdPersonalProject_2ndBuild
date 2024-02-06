using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ShopSlotUI[] shopSlotUI;
    public ItemSlot[] shopSlot;
    public ItemData[] shopItems;


    
    public GameObject purchasePopUp;
    public GameObject errorMessagePopUp;


    public static Shop Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        shopSlot = new ItemSlot[shopSlotUI.Length];

        for (int i = 0; i < shopSlot.Length; i++)
        {
            shopSlot[i] = new ItemSlot();
            shopSlotUI[i].index = i;
            shopSlotUI[i].Clear();
           
        }
        AddItem(shopItems[0]);
        AddItem(shopItems[1]);
        AddItem(shopItems[2]);
        
    }
    public void AddItem(ItemData item)
    {
        ItemSlot emptySlot = GetEmptySlot();
        {
            if (emptySlot != null)
            {
                emptySlot.item = item;
                UpdateUI();
                return;
            }
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < shopSlot.Length; i++)
        {
            if (shopSlot[i].item != null)
                shopSlotUI[i].Set(shopSlot[i]);
            else
                shopSlotUI[i].Clear();
        }
    }

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < shopSlot.Length; ++i)
        {
            if (shopSlot[i].item == null)
                return shopSlot[i];
        }
        return null;
    }
}
