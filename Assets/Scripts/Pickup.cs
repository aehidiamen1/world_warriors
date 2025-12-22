using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public ItemData itemData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Checking if the item can be added to the inventory
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.inventoryData.items[i] == null)
                {
                    inventory.inventoryData.items[i] = itemData; // store the item
                    Instantiate(itemData.itemPrefab, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}