using UnityEngine;

[CreateAssetMenu(fileName = "FloatSO", menuName = "Scriptable Objects/FloatSO")]
public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float _value;

    public float Value
    {
        get { return _value; }
        set { _value = value; }
    }
}
