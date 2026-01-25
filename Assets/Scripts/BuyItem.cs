using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject itemButton;

    [SerializeField] float itemCost;
    [SerializeField] private FloatSO coinCountSO;

    public void PurchaseItem()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        
        // Store the item in the first available slot
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.inventoryData.isFull[i] == false)
            {
                inventory.inventoryData.StoreItem(i, itemButton);
                Instantiate(itemButton, inventory.slots[i].transform, false);
                break;
            }
        }

        // Deduct the cost from the player's coins
        coinCountSO.Value -= itemCost;
    }
}
