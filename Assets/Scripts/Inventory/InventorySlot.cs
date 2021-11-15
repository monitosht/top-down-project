using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour //, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Item item;
    public Image icon;

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

    #region Drag Methods  
    /*
    [SerializeField] private Canvas canvas;
    private RectTransform originalPosition;   

    private void Awake()
    {
        originalPosition = icon.GetComponent<RectTransform>(); 
    }
    
    public void OnDrag(PointerEventData eventData)
    {        
        icon.rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition.anchoredPosition = icon.rectTransform.anchoredPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        icon.rectTransform.anchoredPosition = originalPosition.anchoredPosition;
    }
    */
    #endregion
}

