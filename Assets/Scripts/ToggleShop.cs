using UnityEngine;

public class ToggleShop : MonoBehaviour
{
    [SerializeField] GameObject shopDisplay;
    [SerializeField] GameObject shopDisplayBackground;
    
    bool shopStateActive = false;

    public void OpenOrCloseShop()
    {
        if (shopStateActive)
        {       
            //Close the shop
            shopDisplay.SetActive(false);
            shopDisplayBackground.SetActive(false);
            shopStateActive = false;
        }
        else
        {
            //Open the shop
            shopDisplay.SetActive(true);
            shopDisplayBackground.SetActive(true);
            shopStateActive = true;
        }
    }
}
