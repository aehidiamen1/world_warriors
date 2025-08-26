using UnityEngine;

public class HowToPlayMenuButtonManager : MonoBehaviour
{
    [SerializeField] MainMenuManager.HowToPlayButtons _buttonType;
    public void ButtonClicked()
    {
        MainMenuManager._.HowToPlayButtonClicked(_buttonType);
    }
}
