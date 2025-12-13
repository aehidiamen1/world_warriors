using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    void Start()
    {
        // Use the persistent inventory instance instead of finding it each time
        inventory = Inventory.instance;
    }

    void Update()
    {
        // Make sure inventory exists before trying to use it
        if (inventory == null)
        {
            inventory = Inventory.instance;
            return;
        }

        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }
    
    public void DropItem()
    {
        // When the player clicks the red cross then the item currently in the inventory will be dropped
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}