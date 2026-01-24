using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool reset = false;

    public CanvasGroupFader fader;

    public void GameOver()
    {
        gameOverUI.SetActive(true);

        // Fade in the game over screen
        if (fader != null)
        {
            fader.Fade(true);
        }

        //Pause the game
        Time.timeScale = 0f;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        reset = true;
        Time.timeScale = 1f;
    }
}
