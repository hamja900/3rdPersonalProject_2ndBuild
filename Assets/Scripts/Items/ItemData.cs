using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum equipStatTypeP
{
    atk,
    def,
    hp,
    crit
}
[System.Serializable]
public class ItemDataEquipable
{
    public equipStatTypeP type;
    public int value;
}

[CreateAssetMenu(fileName = "ItemData",menuName ="NewItem")]
public class ItemData : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public string ItemDesc;
    public int itemPrice;
    public bool IsEquipped =false;

    [Header("equip")]
    public ItemDataEquipable equipables;
  
}
