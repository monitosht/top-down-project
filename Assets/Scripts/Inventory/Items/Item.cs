using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite itemSprite = null;  

    public int itemAmount = 1;  
    public bool unique = false;

    public virtual void Use()
    {
        Debug.Log("Use: "+itemName);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
