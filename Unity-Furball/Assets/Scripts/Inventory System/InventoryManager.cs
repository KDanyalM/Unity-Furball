using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;
    
    

    public List<SlotClass> items = new List<SlotClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //sets all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();

        Add(itemToAdd);
        Remove(itemToRemove);

    }
    // Refreshes the UI to place images where item data is held.
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;

                if (items[i].GetItem().isStackable)
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].GetQuantity() + "";
                else
                    slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
            // Ensures there is no crash and checks if there is no item, then there is no sprite.
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
            }
        }
    }

    public bool Add(ItemClass item)
    {
        //   items.Add(item);
        //check if inventory contains item


        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
            slot.AddQuantity(1);
        else
        {
            if (items.Count < slots.Length)
                items.Add(new SlotClass(item, 1));
            else
                return false;
        }
            RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {

        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
                temp.SubQuantity(1);

            else
            {
                SlotClass slotToRemove = new SlotClass();

                if (temp.GetQuantity() > 1) temp.SubQuantity(1);
                else items.Remove(temp);
                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }
            RefreshUI();
        return true;
    }

    public SlotClass Contains(ItemClass item) 
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
            
                return slot;
            
        }

            return null;
    }
}
