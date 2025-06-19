using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 4f;

    private int scoreValue;
    private string colorName;
    private bool isPopped = false;

    private Animator animator; // Deðiþti: SerializeField deðil, dinamik

    [SerializeField] private GameObject popEffectPrefab;

    void Awake()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError($"[BALON] Animator bulunamadý! {gameObject.name} prefab’ýnda Animator yok!");
        }
    }

    public void Setup(int score, string name, GameObject effect)
    {
        scoreValue = score;
        colorName = name;
        popEffectPrefab = effect;
    }

    void Update()
    {
        if (!isPopped)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (isPopped) return;

        isPopped = true;
        Debug.Log($"[BALON] Patlatýldý: {colorName} | Skor: {scoreValue}");

        ScoreManager.instance.UpdateScore(scoreValue);

        if (popEffectPrefab != null)
        {
            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Debug.Log($"[PARTICLE] Efekt oynatýldý: {popEffectPrefab.name}");
        }

        if (animator != null)
        {
            animator.SetTrigger("pop");
        }
        else
        {
            Destroy(gameObject); // Animasyon oynatacak bir þey yoksa direkt sil
        }
    }

    public void OnPopAnimationEnd()
    {
        Debug.LogWarning(" OnPopAnimationEnd() ÇALIÞTI!");
        Destroy(gameObject);
    }

}
