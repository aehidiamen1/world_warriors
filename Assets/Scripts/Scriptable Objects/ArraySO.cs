using UnityEngine;

[CreateAssetMenu(fileName = "ArraySO", menuName = "Scriptable Objects/ArraySO")]
public class ArraySO : ScriptableObject
{
    public bool[] isFull;
    public GameObject[] storedItemPrefabs;
    
    //Sets up the arrays based on inventory size
    public void SetUpArray(int slotCount)
    {
        if (isFull == null || isFull.Length != slotCount)
        {
            isFull = new bool[slotCount];
            storedItemPrefabs = new GameObject[slotCount];
        }
    }
    
    // Stores a powerup in the inventory slot
    public void StoreItem(int slotIndex, GameObject itemPrefab)
    {
        storedItemPrefabs[slotIndex] = itemPrefab;
        isFull[slotIndex] = true;
    }
    
    // Clears the data stored in a specific slot
    public void ClearSlot(int slotIndex)
    {
        storedItemPrefabs[slotIndex] = null;
        isFull[slotIndex] = false;
    }
    
    // Clears the contents of the entire inventory
    public void ClearAll()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i] = false;
            storedItemPrefabs[i] = null;
        }
    }
}
