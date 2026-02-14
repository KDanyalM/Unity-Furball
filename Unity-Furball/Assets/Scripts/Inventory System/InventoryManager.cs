using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject slotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;
    
    

    public List<ItemClass> items = new List<ItemClass>();

    private GameObject[] slots;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        //sets all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

        RefreshUI();

        Add(itemToAdd);
        
    }
    // Refreshes the UI to place images where item data is held.
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemIcon;
            }
            // Ensures there is no crash and checks if there is no item, then there is no sprite.
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public void Add(ItemClass item)
    {
        items.Add(item);
        RefreshUI();
    }

    public void Remove(ItemClass item)
    {
        RefreshUI();
    }
}
