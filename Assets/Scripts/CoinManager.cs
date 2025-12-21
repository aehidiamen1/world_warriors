using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private FloatSO coinCountSO;
    public TMP_Text coinText;

    // Update is called once per frame
    void Update()
    {
        // Update the coin display text
        coinText.text = ": " + coinCountSO.Value.ToString();
    }
}
