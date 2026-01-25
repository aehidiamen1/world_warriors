using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject itemButton;

    [SerializeField] float itemCost;
    [SerializeField] private FloatSO coinCountSO;

    bool canPurchase = false;

    public void PurchaseItem()
    {
        //Check if the player has enough coins to purchase the item
        if (coinCountSO.Value >= itemCost)
        {
            canPurchase = true;
        }
        else if (coinCountSO.Value < itemCost)
        {
            // Player doesn't have enough coins so exit the function
            Debug.Log("Not enough coins to purchase this item.");
            canPurchase = false;
            return;
        }

        // If the player can purchase the item, add it to their inventory
        if (canPurchase)
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
}
