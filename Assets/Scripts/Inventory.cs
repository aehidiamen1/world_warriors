using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private ArraySO isFull;
    [SerializeField]
    public GameObject[] slots;
    private bool[] runtimeValues;

    private void Start()
    {
        // Create a runtime copy to use during Play Mode
        runtimeValues = (bool[])isFull.Value.Clone();
    }

    public bool IsSlotFull(int index)
    {
        return runtimeValues[index];
    }

    public void SetSlotFull(int index, bool value)
    {
        runtimeValues[index] = value;
    }
}