using UnityEngine;

[CreateAssetMenu(fileName = "ArraySO", menuName = "Scriptable Objects/ArraySO")]
public class ArraySO : ScriptableObject
{
    [SerializeField]
    private bool[] _value;

    public bool[] Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
