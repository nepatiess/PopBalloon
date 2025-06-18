using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 4f;

    private int scoreValue;
    private string colorName;

    [SerializeField] private GameObject popEffectPrefab;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void Setup(int score, string name, GameObject effect)
    {
        scoreValue = score;
        colorName = name;
        popEffectPrefab = effect;
    }

    private void OnMouseDown()
    {
        Debug.Log($"[BALON] Patlatýldý: {colorName} | Skor: {scoreValue}");

        ScoreManager.instance.UpdateScore(scoreValue);
        PlayPopEffect();
        Destroy(gameObject);
    }

    void PlayPopEffect()
    {
        if (popEffectPrefab != null)
        {
            GameObject effect = Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Debug.Log($"[PARTICLE] Pop efekti çalýþtý: {popEffectPrefab.name} | Pozisyon: {transform.position}");

            // Particle System bileþeni var mý kontrol edelim
            if (effect.GetComponent<ParticleSystem>() == null)
                Debug.LogWarning($"[PARTICLE] Uyarý: {popEffectPrefab.name} prefab'ýnda Particle System yok!");
        }
        else
        {
            Debug.LogWarning("[PARTICLE] Efekt prefab atanmadý, efekt oynatýlamadý.");
        }
    }
}
