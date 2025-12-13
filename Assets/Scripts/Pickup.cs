using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    void Start()
    {
        // Use the persistent inventory instance instead of finding it each time
        inventory = Inventory.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Make sure inventory exists before trying to use it
            if (inventory == null)
            {
                inventory = Inventory.instance;
            }

            //Checking if the item can be added to the inventory
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    //Add item to inventory
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}