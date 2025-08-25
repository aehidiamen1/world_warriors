using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private bool _debugMode;
    public enum MainMenuButtons { play, options, howtoplay, quit };
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
 