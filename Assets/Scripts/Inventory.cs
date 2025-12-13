using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public static bool[] isFull;
    public static GameObject[] slots;
    public GameObject inventoryPanel;
    private static GameObject persistentInventoryPanel;
    public GameObject[] slotsSetup;

    void Awake()
    {
        if (inventory == null)
        {
            inventory = this;

            if (slots == null || slots.Length == 0)
            {
                slots = slotsSetup;
            }

            if (isFull == null || isFull.Length == 0)
            {
                isFull = new bool[slots.Length];
            }

            if (inventoryPanel != null && persistentInventoryPanel == null)
            {
                DontDestroyOnLoad(inventoryPanel);
                persistentInventoryPanel = inventoryPanel;
            }
        }
        else
        {
            inventory = this;

            if (inventoryPanel != null && persistentInventoryPanel != null)
            {
                Destroy(inventoryPanel);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure our arrays are the right size
        if (isFull == null || isFull.Length == 0)
        {
            isFull = new bool[slots.Length];
        }
    }
}
