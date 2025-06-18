using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 2f;
    public int scoreValue;
    public string colorName;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void Pop()
    {
        Destroy(gameObject);
    }
}
