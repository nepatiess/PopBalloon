using UnityEngine;
using TMPro; // TMP_Text kullanmak i�in
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // Bunu UI'dan ba�laman laz�m

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
        Debug.Log("Yeni skor: " + score); // UI yazmasa bile burada g�r�n�r

        if (scoreText != null)
            scoreText.text = score.ToString();
        else
            Debug.LogWarning("scoreText ba�l� de�il!");

        // Oyun sonu kontrol�
        if (score >= 50 || score < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Oyun bitti! GameOver sahnesine ge�iliyor...");
        // Burada GameOver sahnesinin ad�n� yaz, �rnek: "GameOver"
        SceneManager.LoadScene("GameOver");
    }

}