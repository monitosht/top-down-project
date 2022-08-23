using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{   
    //[HideInInspector] 
    public Item item;
    public Image icon;
    public GameObject buttonParent;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemSprite;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false; 
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void UpdateSlot(Item newItem, GameObject newIcon, InventorySlot oldInventorySlot)
    {
        if(item == null)
        {

            icon.transform.SetParent(oldInventorySlot.buttonParent.transform);            
            icon.GetComponent<RectTransform>().anchoredPosition = oldInventorySlot.GetComponent<RectTransform>().position;
            icon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;       

            newIcon.transform.SetParent(buttonParent.transform);
            newIcon.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().position;
            newIcon.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                        
            AddItem(newItem);
            oldInventorySlot.ClearSlot();

            /*var tempIcon = icon;
            icon = oldInventorySlot.icon;
            oldInventorySlot.icon = tempIcon;*/
        }

        Debug.Log("New item dropped into slot");    
    }
}

