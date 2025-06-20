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

    }


    public void Setup(int score, string name, GameObject effect)
    {
        scoreValue = score;
        colorName = name.ToLower();
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

        // score updatei
        ScoreManager.instance.UpdateScore(scoreValue);

        // balon tagine göre oyun sonu balon sayýsý artýrýlýyor
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


        if (popEffectPrefab != null)
        {
            Instantiate(popEffectPrefab, transform.position, Quaternion.identity);
            
        }

        // anim baþlat
        if (animator != null)
        {
            animator.SetTrigger("pop");
        }
        else
        {
            Destroy(gameObject); // anim yoksa direkt sil
        }

        // ses efekti
        if (popSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(popSound);
        }

    }

    // anim sonu
    public void OnPopAnimationEnd()
    {
        Destroy(gameObject);
    }
}
