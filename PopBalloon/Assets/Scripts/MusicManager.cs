using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource menuMusic;
    public AudioSource gameMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne geçince kaybolmasın
            SceneManager.sceneLoaded += OnSceneLoaded; // BU ÇOK ÖNEMLİ ✅
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayMenuMusic()
    {
        StopAllMusic();
        if (menuMusic != null)
        {
            menuMusic.Play();
            Debug.Log("[MusicManager] Menu müziği başladı.");
        }
    }

    public void PlayGameMusic()
    {
        StopAllMusic();
        if (gameMusic != null)
        {
            gameMusic.Play();
            Debug.Log("[MusicManager] Game müziği başladı: " + gameMusic.clip.name);
        }
    }

    public void StopAllMusic()
    {
        if (menuMusic != null) menuMusic.Stop();
        if (gameMusic != null) gameMusic.Stop();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"[MusicManager] Sahne yüklendi: {scene.name}");

        if (scene.name == "MainMenu")
        {
            PlayMenuMusic();
        }
        else if (scene.name == "GameScene")
        {
            PlayGameMusic();
        }
        else if (scene.name == "GameOver")
        {
            StopAllMusic();
        }
    }
}
