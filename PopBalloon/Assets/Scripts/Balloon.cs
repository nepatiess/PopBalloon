using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue;
    public string colorName;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        ScoreManager.Instance.AddScore(scoreValue);
        Destroy(gameObject); // Patlama efekti ekleyeceksen önce Instantiate()
    }
}
