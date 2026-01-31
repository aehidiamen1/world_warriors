using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static bool reset = false;

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        reset = true;
    }
}
