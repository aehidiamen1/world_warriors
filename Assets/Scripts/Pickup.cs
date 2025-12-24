using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            
            // Store the item in the first available slot
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.inventoryData.isFull[i] == false)
                {
                    inventory.inventoryData.StoreItem(i, itemButton);
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}