using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : GenericSingleton<GameManager>
{
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetTimeScale(float newTimeScale)
    {
        Time.timeScale = newTimeScale;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
