using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string SceneName;

    public void ExitScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
