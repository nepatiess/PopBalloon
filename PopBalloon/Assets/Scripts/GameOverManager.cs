using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text lastScoreText;
    public TMP_Text highScoreText;
    public TMP_Text blueCountText;
    public TMP_Text greenCountText;
    public TMP_Text blackCountText;

    void Start()
    {
        MusicManager.instance.StopAllMusic();

        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        int blue = PlayerPrefs.GetInt("BlueCount", 0);
        int green = PlayerPrefs.GetInt("GreenCount", 0);
        int black = PlayerPrefs.GetInt("BlackCount", 0);

        lastScoreText.text = lastScore.ToString();
        highScoreText.text = highScore.ToString();
        blueCountText.text = blue.ToString();
        greenCountText.text = green.ToString();
        blackCountText.text = black.ToString();
    }
}
