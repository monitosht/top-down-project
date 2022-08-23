using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public int itemAmount = 1;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool pickedUp = Inventory.instance.Add(item);

        if(pickedUp)
        {
            Destroy(gameObject);
        }        
    }
}
