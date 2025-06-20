using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // kendi sahne adýný yaz
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // ana menü sahnenin adýný yaz
    }
}
