using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentType;
    public int defenseIncrease;
    public int damageIncrease;
    public int magicIncrease;

    public override void Use()
    {
        base.Use();
        RemoveFromInventory();
        EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot { Head, Body, Jewellery }