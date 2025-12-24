using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public ArraySO inventoryData;
    public GameObject[] slots;
    
    void Start()
    {
        inventoryData.SetUpArray(slots.Length);
        RestoreInventory();
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-find slots in the new scene and restore
        Invoke(nameof(FindSlotsAndRestore), 0.1f);
    }
    
    // Finds all of the slot components in the scene and restores the items in them
    void FindSlotsAndRestore()
    {
        Slot[] slotComponents = FindObjectsByType<Slot>(FindObjectsSortMode.None);
        
        // Sort by slot index to ensure correct order
        System.Array.Sort(slotComponents, (a, b) => a.i.CompareTo(b.i));
        
        slots = new GameObject[slotComponents.Length];
        for (int i = 0; i < slotComponents.Length; i++)
        {
            slots[i] = slotComponents[i].gameObject;
        }
        
        RestoreInventory();
    }
    
    void RestoreInventory()
    {
        for (int i = 0; i < inventoryData.isFull.Length && i < slots.Length; i++)
        {
            // Clear any existing items first
            foreach (Transform child in slots[i].transform)
            {
                Destroy(child.gameObject);
            }
            
            // Restore saved items
            if (inventoryData.isFull[i] && inventoryData.storedItemPrefabs[i] != null)
            {
                Instantiate(inventoryData.storedItemPrefabs[i], slots[i].transform, false);
            }
        }
    }
}