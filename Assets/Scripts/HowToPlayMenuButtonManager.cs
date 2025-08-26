using UnityEngine;

public class HowToPlayMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuButtonManager.HowToPlayButtons _buttonType;
    public void ButtonClicked()
    {
        MainMenuManager._.MainMenuButtonClicked(_buttonType);
    }
}
