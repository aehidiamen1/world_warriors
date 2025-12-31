using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        //Pause the game
        Time.timeScale = 0f;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
