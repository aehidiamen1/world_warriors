using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public ArraySO isFull;
    [SerializeField]
    public GameObject[] slots;

    public bool IsSlotFull(int index)
    {
        return isFull.Value[index];
    }

    public void SetSlotFull(int index, bool value)
    {
        isFull.Value[index] = value;
    }
}