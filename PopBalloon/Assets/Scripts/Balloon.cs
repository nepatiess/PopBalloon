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
            Debug.LogError($"[BALON] Animator bulunamadý! {gameObject.name} prefab’ýnda Animator yok!");
        }

        if (audioSource == null)
        {
            Debug.LogWarning($"[BALON] AudioSource yok! {gameObject.name} prefab'ýna AudioSource eklemelisin.");
        }
    }


    public void Setup(int score, string name, GameObject effect)
    {
        scoreValue = score;
        colorName = name.ToLower(); // küçük harfe çevir, karþýlaþtýrma kolay olsun
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

        // Skor güncellemesi
        ScoreManager.instance.UpdateScore(scoreValue);

        // Balon rengine göre sayaç artýr
        // Balonun tag'ine göre sayaç artýr
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
            Debug.LogWarning($"[BALON] Tanýmsýz tag: {gameObject.tag}");
        }


        // Efekt varsa patlat
        if (popEffectPrefab != null)
        {
            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            Debug.Log($"[PARTICLE] Efekt oynatýldý: {popEffectPrefab.name}");
        }

        // Animasyon varsa baþlat
        if (animator != null)
        {
            animator.SetTrigger("pop");
        }
        else
        {
            Destroy(gameObject); // Animasyon yoksa doðrudan sil
        }

        // Ses efekti çal
        if (popSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(popSound);
        }

    }

    // Animasyonun sonunda çaðrýlacak
    public void OnPopAnimationEnd()
    {
        Debug.LogWarning("OnPopAnimationEnd() ÇALIÞTI!");
        Destroy(gameObject);
    }
}
