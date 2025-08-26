using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private bool _debugMode;
    //Setting the possible values of the main menu buttons
    public enum MainMenuButtons { play, options, howtoplay, quit };
    // Displaying a message when the code is debugged
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked" + buttonClicked.ToString());
    }
    private void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }
    }
}
 