using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
