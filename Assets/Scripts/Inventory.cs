using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ArraySO inventoryData;
    public GameObject[] slots;

    public GameObject itemButtonPrefab;
    
    void Awake()
    {
        // Initialize once
        if (inventoryData == null || inventoryData.isFull.Length != slots.Length)
        {
            inventoryData.isFull = new bool[slots.Length];
        }
    }

    
    void Start()
    {
        for (int i = 0; i < inventoryData.isFull.Length; i++)
        {
            if (inventoryData.isFull[i] && slots[i].transform.childCount == 0)
            {
                Instantiate(itemButtonPrefab, slots[i].transform, false);
            }
        }
    }
}