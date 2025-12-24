using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        // If the slot is empty, clear its data in the inventory
        if (transform.childCount <= 0)
        {
            inventory.inventoryData.ClearSlot(i);
        }
    }
    
    public void DropItem()
    {
        // When the red cross is clicked the item is dropped
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
        
        inventory.inventoryData.ClearSlot(i);
    }
}