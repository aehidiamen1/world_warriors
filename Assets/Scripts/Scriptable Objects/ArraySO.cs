using UnityEngine;

[CreateAssetMenu(fileName = "ArraySO", menuName = "Scriptable Objects/ArraySO")]
public class ArraySO : ScriptableObject
{
    public bool[] isFull;
    public GameObject[] storedItemPrefabs;
    
    public void Initialize(int slotCount)
    {
        if (isFull == null || isFull.Length != slotCount)
        {
            isFull = new bool[slotCount];
            storedItemPrefabs = new GameObject[slotCount];
        }
    }
    
    public void StoreItem(int slotIndex, GameObject itemPrefab)
    {
        storedItemPrefabs[slotIndex] = itemPrefab;
        isFull[slotIndex] = true;
    }
    
    public void ClearSlot(int slotIndex)
    {
        storedItemPrefabs[slotIndex] = null;
        isFull[slotIndex] = false;
    }
    
    public void ClearAll()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i] = false;
            storedItemPrefabs[i] = null;
        }
    }
}
