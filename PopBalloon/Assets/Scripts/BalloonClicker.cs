using UnityEngine;

public class BalloonClicker : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Balona týklandý: " + gameObject.name);

        if (CompareTag("BlackBalloon"))
        {
            ScoreManager.instance.UpdateScore(-2);
        }
        else if (CompareTag("BlueBalloon"))
        {
            ScoreManager.instance.UpdateScore(1);
        }
        else if (CompareTag("GreenBalloon"))
        {
            ScoreManager.instance.UpdateScore(5);
        }

        Destroy(gameObject);
    }
}