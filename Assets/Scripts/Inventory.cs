using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public bool[] isFull;
    public GameObject[] slots;

    void Awake()
    {
        // Check if an inventory already exists
        if (instance == null)
        {
            // This is the first inventory, make it persistent (the one that remains over all the scenes)
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an inventory already exist, then destroy the one that is going to be loaded
            Destroy(gameObject);
        }
    }
}