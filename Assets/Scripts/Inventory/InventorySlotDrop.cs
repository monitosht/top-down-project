using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotDrop : MonoBehaviour, IDropHandler
{
    private InventorySlot inventorySlot;

    void Awake()
    {
        inventorySlot = GetComponent<InventorySlot>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {       
            GameObject icon = eventData.pointerDrag;
            InventoryDrag newItem = icon.GetComponent<InventoryDrag>();
            InventorySlot oldInventorySlot = newItem.inventorySlot;

            newItem.dropped = true;

            inventorySlot.UpdateSlot(oldInventorySlot.item, icon, oldInventorySlot);                 
        }   
    }
}
