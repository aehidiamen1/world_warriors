using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    //Setting the possible values of the main menu buttons
    public enum MainMenuButtons { play, options, how_To_Play, quit };
    public enum HowToPlayButtons { back };
    public enum OptionsButtons { back };
    [SerializeField] private string _sceneToLoadAfterClickingPlay;

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

    // Displaying a message when the button is clicked in the debug console
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked: " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.play:
                PlayClicked();
                break;
            case MainMenuButtons.options:
                break;
            case MainMenuButtons.how_To_Play:
                break;
            case MainMenuButtons.quit:
                QuitGame();
                break;
            default:
                Debug.Log("Button clicked that wasn't implemented in MainMenuManager Method");
                break;
        }
    }
    
    public void ReturnToMainMenu()
    {

    }
    //Method to run when the how_to_play button is clicked
    public void HowToPlayButtonClicked(HowToPlayButtons buttonClicked)
    {
        //When the back button is clicked return to main menu
        switch (buttonClicked)
        {
            case HowToPlayButtons.back:
                ReturnToMainMenu();
                break;
        }
    }
    public void OptionsButtonsClicked(OptionsButtons buttonClicked)
    {
        //When the back button is clicked return to main menu
        switch (buttonClicked)
        {
            case OptionsButtons.back:
                ReturnToMainMenu();
                break;
        }
    }
    private void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }
    }
    public void PlayClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingPlay);
    }
    //Method to quit the game even if inside playmode 
    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
 