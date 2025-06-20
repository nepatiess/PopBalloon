using UnityEngine;
using TMPro; // TMP_Text kullanmak i�in
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText; // Bunu UI'dan ba�laman laz�m

    // ka� tane balon vurduk onun say�s�
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

        // En y�ksek skoru g�ncelle
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        // Mevcut skor ve balon say�lar�n� kaydet
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.SetInt("BlueCount", blueBalloonCount);
        PlayerPrefs.SetInt("GreenCount", greenBalloonCount);
        PlayerPrefs.SetInt("BlackCount", blackBalloonCount);

        PlayerPrefs.Save(); // BU SATIR �OK �NEML�!

        SceneManager.LoadScene("GameOver");
    }


}