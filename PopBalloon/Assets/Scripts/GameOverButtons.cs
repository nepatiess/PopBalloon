using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // kendi sahne ad�n� yaz
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // ana men� sahnenin ad�n� yaz
    }
}
