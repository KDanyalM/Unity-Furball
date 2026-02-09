using UnityEngine;

// Class is "abstract" because it is not being created DIRECTLY, and is essentially just to be inherited from, a "blueprint" of sorts.
public abstract class ItemClass : ScriptableObject
{

    // Grants each item (reguardless of type) an item name and icon
    [Header("Item")] //Data shared across all items
    public string itemName;
    public Sprite itemIcon;


    public abstract ItemClass GetItem();
    public abstract ConsumableClass GetConsumable();
    public abstract MiscClass GetMisc();
    public abstract DecorClass GetDecor();
}
