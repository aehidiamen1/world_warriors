using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [SerializeField] private MainMenuManager.MainMenuButtons _buttonType;
    //Code to run when the button is clicked.
    public void ButtonClicked()
    {
        MainMenuManager._.MainMenuButtonClicked(_buttonType);

    }
}
