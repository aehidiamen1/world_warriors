using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;

    [SerializeField] 
    private ArraySO inventorySO;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the array if it's not set or doesn't match slot count
        if (inventorySO.Values == null || inventorySO.Values.Length != slots.Length)
        {
            inventorySO.Values = new bool[slots.Length];
            Debug.Log("Inventory slots initialized.");
        }
    }
    
    // Helper methods for easier access
    public bool IsSlotFull(int index)
    {
        return inventorySO.GetValue(index);
    }
    
    public void SetSlotFull(int index, bool isFull)
    {
        inventorySO.SetValue(index, isFull);
    }
}