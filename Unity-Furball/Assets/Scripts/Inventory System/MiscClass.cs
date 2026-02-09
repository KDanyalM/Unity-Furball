using UnityEngine;

[CreateAssetMenu(fileName = "new Misc Class", menuName = "Item/Misc")] // Allows us to right click in the editor and create class as an asset file
public class MiscClass : ItemClass
{


    //Data specific to Misc class
    public override ItemClass GetItem() { return this; }
    public override ConsumableClass GetConsumable() { return null; }
    public override MiscClass GetMisc() { return this; }
    public override DecorClass GetDecor() { return null; }
}
