using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;

    [SerializeField] 
    private ArraySO inventorySO;
    
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