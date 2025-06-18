using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // Bu alan dolu olmalý!

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int value)
    {
        score += value;
        Debug.Log("Yeni skor: " + score); // Bakalým çalýþýyor mu

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("scoreText baðlý deðil!");
        }
    }
}
