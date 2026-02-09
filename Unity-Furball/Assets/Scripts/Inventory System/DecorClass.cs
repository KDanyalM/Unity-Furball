using UnityEngine;


[CreateAssetMenu(fileName = "new Decor Class", menuName = "Item/Decor")] // Allows us to right click in the editor and create class as an asset file
public class DecorClass : ItemClass
{

    [Header("Decoration")] //Data specific to Decor class

    public DecorationType decorationType;

    public enum DecorationType
    {
        bed,
        sofa,
        TV,
        table
    }
    public override ItemClass GetItem() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override DecorClass GetDecor() { return this; }
}
