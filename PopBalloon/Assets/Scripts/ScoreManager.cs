using UnityEngine;
using TMPro; // TMP_Text kullanmak için
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // Bunu UI'dan baðlaman lazým

    void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int value)
    {
        score += value;
        Debug.Log("Yeni skor: " + score); // UI yazmasa bile burada görünür

        if (scoreText != null)
            scoreText.text = score.ToString();
        else
            Debug.LogWarning("scoreText baðlý deðil!");

        // Oyun sonu kontrolü
        if (score >= 50 || score < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Oyun bitti! GameOver sahnesine geçiliyor...");
        // Burada GameOver sahnesinin adýný yaz, örnek: "GameOver"
        SceneManager.LoadScene("GameOver");
    }

}