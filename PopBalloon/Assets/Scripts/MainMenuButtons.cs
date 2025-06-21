using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        MusicManager.instance.StopAllMusic(); // afresh quite
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit(); // quit func
    }
}
