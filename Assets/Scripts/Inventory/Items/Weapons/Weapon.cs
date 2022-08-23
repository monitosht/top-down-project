using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public int defenseIncrease;
    public int damageIncrease;
    public int magicIncrease;

    public Sprite weaponSprite;
    public float fireRate;
    public float deviation;

    public override void Use()
    {
        base.Use();
        RemoveFromInventory();
        //equip weapon using weapon manager;
    }
}
