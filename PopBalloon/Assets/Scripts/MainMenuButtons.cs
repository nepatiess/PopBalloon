using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    void Start()
{
    MusicManager.instance.PlayMenuMusic();
}


    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // kendi sahne adını yaz
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
