using UnityEngine;

[CreateAssetMenu(fileName = "ArraySO", menuName = "Scriptable Objects/ArraySO")]
public class ArraySO : ScriptableObject
{
    [SerializeField]
    private bool[] _values;

    public bool[] Values
    {
        get { return _values; }
        set { _values = value; }
    }   

    public bool GetValue(int index)
    {
        if (_values != null && index >= 0 && index < _values.Length)
        {
            return _values[index];
        }
        Debug.LogWarning("Index out of range or array is null!");
        return false;
    }

    public void SetValue(int index, bool value)
    {
        if (_values != null && index >= 0 && index < _values.Length)
        {
            _values[index] = value;
        }
        else
        {
            Debug.LogWarning("Index out of range or array is null!");
        }
    }
}
