using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    [HideInInspector] public bool dropped = false;
    private Canvas canvas; 
    public InventorySlot inventorySlot;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    #region Drag Methods  
    public void OnDrag(PointerEventData eventData)
    {        
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.75f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(dropped == false)
        {
            rectTransform.anchoredPosition = Vector3.zero;
        }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        dropped = false;
    }
    #endregion
}
