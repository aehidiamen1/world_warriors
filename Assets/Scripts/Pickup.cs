using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject itemButton;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Checking if the item can be added to the inventory
            for (int i = 0; i < Inventory.slots.Length; i++)
            {
                // Check if this slot is empty
                if (Inventory.isFull[i] == false)
                {
                    // Add item to the inventory
                    Inventory.isFull[i] = true;
                    Instantiate(itemButton, Inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
