
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private PlayerInputHandler inputHandler;

    public GameObject inventoryUI;
    public Transform itemsParent;
    private InventorySlot[] slots;
    

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        inputHandler = FindObjectOfType<PlayerInputHandler>();
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        if(inputHandler.inventoryInput == true)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inputHandler.inventoryInput = false;
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
