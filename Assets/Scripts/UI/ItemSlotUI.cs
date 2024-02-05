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
    public GameObject selectedItemPopUp;

    public int index;

    

    private void OnEnable()
    {
      for(int i = 0; i<Inventory.Instance.slots.Length; i++)
        {
            if (Inventory.Instance.slots[i].item.isEquipped)
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
        if(selectedItemPopUp.activeInHierarchy)
        {
            return;
        }
        Inventory.Instance.SelectedItem(index);
        selectedItemPopUp.SetActive(true);
    }
}
