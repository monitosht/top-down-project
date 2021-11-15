using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite itemSprite = null;  

    public int itemAmount = 1;  

    public virtual void Use()
    {
        Debug.Log("Use: "+itemName);
    }
}
