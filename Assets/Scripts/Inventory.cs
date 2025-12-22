using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ArraySO inventoryData;
    public GameObject[] slots;

    void Awake()
    {
        // Initialize once
        if (inventoryData.items == null)
        {
            inventoryData.items = new ItemData[slots.Length];
        }
    }

    
    void Start()
    {
        for (int i = 0; i < inventoryData.items.Length; i++)
        {
            if (inventoryData.items[i] != null && slots[i].transform.childCount == 0)
            {
                Instantiate(inventoryData.items[i].itemPrefab, slots[i].transform, false);
            }
        }
    }
}