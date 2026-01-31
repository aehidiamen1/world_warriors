using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime; 

    public GameOverScreen GameOverScreen;

    // Update is called once per frame
    void Update()
    {
        //Timer countdown
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime < 10)
            {
                // Change timer text color to red when less than 10 seconds remain
                timerText.color = Color.red;
            }
        }
        else if (remainingTime < 0)
        {
            // Time has run out call the game over function
            remainingTime = 0;
            GameOverScreen.GameOver();
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
