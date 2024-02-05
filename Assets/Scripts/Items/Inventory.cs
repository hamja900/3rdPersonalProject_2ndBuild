using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot
{
    public ItemData item;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;
    public ItemData[] items;

    public GameObject inventoryWindow;

    [Header("SelectedItem")]
    public UnityEngine.UI.Image sprite;
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public GameObject selectedItemPopUp;
    public GameObject CancleBtn;
    public GameObject equipBtn;
    public GameObject unEquipBtn;
    public Text selectedItemName;
    public Text selectedItemStatName;
    public Text selectedItemStatValue;

    public int extraAtk;
    public int extraDef;
    public int extraHP;
    public int extraCrit;

    public int totalAtk;
    public int totalDef;
    public int totalHP;
    public int totalCrit;

    private int curEquipIndex;

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        selectedItemPopUp.SetActive(false);

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
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].item != null)
                return slots[i];
        }
        return null;
    }

    public void SelectedItem(int index)
    {
        if (slots[index].item == null)
        {
            return;
        }
        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemStatName.text = selectedItem.item.equipables.type.ToString();
        selectedItemStatValue.text = selectedItem.item.equipables.value.ToString();

        equipBtn.SetActive(!slots[index].item.isEquipped);
        unEquipBtn.SetActive(slots[index].item.isEquipped);
        CancleBtn.SetActive(true);
    }

    public void EquipItem(int index)
    {
        selectedItem.item.isEquipped = true;
        AddExtraStats();
    }

    public void UnEquipItem(int index)
    {
        selectedItem.item.isEquipped=false;
        AddExtraStats();
    }
    public void OnEquipBtn()
    {
        EquipItem(selectedItemIndex);
        selectedItemPopUp.SetActive(false);
    }
    public void OnUnEquipBtn()
    {
        UnEquipItem(selectedItemIndex);
        selectedItemPopUp.SetActive(false);
    }

    public void OnCancleBtn()
    {
        selectedItemPopUp.SetActive(false);
    }
    
    public void AddExtraStats()
    {
        extraAtk = 0;
        extraDef = 0;
        extraHP = 0;
        extraCrit = 0;

        for (int i = 0; i <slots.Length; i++)
        {
            if (slots[i].item.isEquipped)
            {
                if (slots[i].item.equipables.type == equipStatTypeP.atk)
                    extraAtk += slots[i].item.equipables.value;
                else if (slots[i].item.equipables.type == equipStatTypeP.def)
                    extraDef += slots[i].item.equipables.value;
                else if (slots[i].item.equipables.type == equipStatTypeP.hp)
                    extraHP += slots[i].item.equipables.value;
                else if (slots[i].item.equipables.type == equipStatTypeP.crit)
                    extraCrit += slots[i].item.equipables.value;
               
            }
        }
    }

}
