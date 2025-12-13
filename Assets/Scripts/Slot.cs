using UnityEngine;

public class Slot : MonoBehaviour
{
    public int i;

    // Update is called once per frame
    void Update()
    {
        if (Inventory.isFull == null || i >= Inventory.isFull.Length)
        {
            return;
        }

        if (transform.childCount <= 0)
        {
            Inventory.isFull[i] = false;
        }
    }
    
    public void DropItem()
    {
        // When the player clicks the red cross then the item currently in the inventory will be dropped
        foreach (Transform child in transform)
        {
            Spawn spawnScript = child.GetComponent<Spawn>();
            if (spawnScript != null)
            {
                spawnScript.SpawnDroppedItem();
            }
            GameObject.Destroy(child.gameObject);
        }
    }
}
