using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // kendi sahne ad�n� yaz
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
