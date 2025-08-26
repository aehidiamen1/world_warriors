using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    //Setting the possible values of the main menu buttons
    public enum MainMenuButtons { play, options, howtoplay, quit };

    // Method that unity calls when the screen starts up
    public void Awake()
    {
        //Checks whether more than one script is trying to set the value of the singleton.       
        if (_ == null) //Checks if _ hasn't been set to anything
        {
            _ = this;
        }
        else
        {
            Debug.LogError("There are more than one MainMenuManagers in the scene");
        }
    }

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
 