using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    // kaç tane balon vurduk onun sayýsý
    public int blueBalloonCount = 0;
    public int greenBalloonCount = 0;
    public int blackBalloonCount = 0;


    // high score 
    private int highScore = 0;

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

        if (scoreText != null)
            scoreText.text = score.ToString();
        
        // 0>x or x>50
        if (score >= 50 || score < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        // en yüksek skoru güncelle
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        // mevcut skor ve balon sayýlarýný kaydet
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.SetInt("BlueCount", blueBalloonCount);
        PlayerPrefs.SetInt("GreenCount", greenBalloonCount);
        PlayerPrefs.SetInt("BlackCount", blackBalloonCount);

        PlayerPrefs.Save();

        SceneManager.LoadScene("GameOver");
    }


}