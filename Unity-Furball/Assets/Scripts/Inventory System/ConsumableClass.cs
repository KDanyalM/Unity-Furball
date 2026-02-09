using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable Class", menuName = "Item/Consumable")] // Allows us to right click in the editor and create class as an asset file
public class ConsumableClass : ItemClass
{
    [Header("Consumable")] //Data specific to Consumable class
    public float healthAdded;

    // enum is just a list of options our different items can be named as, it basically just means ConsumableType is applied to each item, and teach item can only be one of those.
    public ConsumableType consumableType;
    public enum ConsumableType
    {
        apple,
        orange,
        flour,
        water,
        sugar,
        applepie
        
            

    }
    public override ItemClass GetItem() { return this; }
    public override ConsumableClass GetConsumable() { return this; }
    public override MiscClass GetMisc() { return null; }
    public override DecorClass GetDecor() { return null; }
}
