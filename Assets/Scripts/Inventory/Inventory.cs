using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory detected.");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySize;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= inventorySize)
        {
            Debug.Log("Not enough space in inventory to pick up item.");

            return false;            
        }      
        
        items.Add(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
