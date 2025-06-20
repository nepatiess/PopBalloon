using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float speed = 4f;

    private int scoreValue;
    private string colorName;
    private bool isPopped = false;

    private Animator animator;
    [SerializeField] private GameObject popEffectPrefab;


    [SerializeField] private AudioClip popSound;
    private AudioSource audioSource;


    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (animator == null)
        {
            Debug.LogError($"[BALON] Animator bulunamad�! {gameObject.name} prefab��nda Animator yok!");
        }

        if (audioSource == null)
        {
            Debug.LogWarning($"[BALON] AudioSource yok! {gameObject.name} prefab'�na AudioSource eklemelisin.");
        }
    }


    public void Setup(int score, string name, GameObject effect)
    {
        scoreValue = score;
        colorName = name.ToLower(); // k���k harfe �evir, kar��la�t�rma kolay olsun
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

        Debug.Log($"[BALON] Patlat�ld�: {colorName} | Skor: {scoreValue}");

        // Skor g�ncellemesi
        ScoreManager.instance.UpdateScore(scoreValue);

        // Balon rengine g�re saya� art�r
        // Balonun tag'ine g�re saya� art�r
        if (CompareTag("BlueBalloon"))
        {
            ScoreManager.instance.blueBalloonCount++;
        }
        else if (CompareTag("GreenBalloon"))
        {
            ScoreManager.instance.greenBalloonCount++;
        }
        else if (CompareTag("BlackBalloon"))
        {
            ScoreManager.instance.blackBalloonCount++;
        }
        else
        {
            Debug.LogWarning($"[BALON] Tan�ms�z tag: {gameObject.tag}");
        }


        // Efekt varsa patlat
        if (popEffectPrefab != null)
        {
            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Debug.Log($"[PARTICLE] Efekt oynat�ld�: {popEffectPrefab.name}");
        }

        // Animasyon varsa ba�lat
        if (animator != null)
        {
            animator.SetTrigger("pop");
        }
        else
        {
            Destroy(gameObject); // Animasyon yoksa do�rudan sil
        }

        // Ses efekti �al
        if (popSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(popSound);
        }

    }

    // Animasyonun sonunda �a�r�lacak
    public void OnPopAnimationEnd()
    {
        Debug.LogWarning("OnPopAnimationEnd() �ALI�TI!");
        Destroy(gameObject);
    }
}
