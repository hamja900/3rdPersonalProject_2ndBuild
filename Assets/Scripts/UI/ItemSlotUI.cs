using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public UnityEngine.UI.Button button;
    public UnityEngine.UI.Image image;
    public GameObject equipMark;
    private ItemSlot curSlot;

    public int index;

    

    private void Update()
    {
        
       if(curSlot != null)
        {
            if (curSlot.item.IsEquipped == true)
            {
                equipMark.SetActive(true);
            }
            else
            {
                equipMark.SetActive(false);
            }
        }
    }

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        image.gameObject.SetActive(true);
        image.sprite = slot.item.sprite;
    }
    public void Clear()
    {
        curSlot = null;
        image.gameObject.SetActive(false);
    }

    public void OnBtnClick()
    {
        Inventory.Instance.SelectedItem(index);
        
    }
}
