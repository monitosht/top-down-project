using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged (Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {
        int slots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[slots];
        inventory = Inventory.instance;
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentType;

        Equipment currentItem = null;

        if(currentEquipment[slotIndex] != null)
        {
            currentItem = currentEquipment[slotIndex];
            inventory.Add(currentItem);
        }

        currentEquipment[slotIndex] = newItem;

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, currentItem);
        }
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment currentItem = currentEquipment[slotIndex];
            inventory.Add(currentItem);

            currentEquipment[slotIndex] = null;

            if(onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, currentItem);
            }            
        }
    }
}