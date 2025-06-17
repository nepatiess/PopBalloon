using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [System.Serializable]
    public class BalloonType
    {
        public string name; // örn: "Mavi"
        public Sprite sprite; // o balonun görseli
        public int score; // patlatýlýnca verilen puan
    }

    public List<BalloonType> balloonTypes; // Inspector'dan tanýmlanacak
    public GameObject balloonPrefab;
    public float spawnInterval = 1f;
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = -5f;

    void Start()
    {
        StartCoroutine(SpawnBalloons());
    }

    IEnumerator SpawnBalloons()
    {
        while (true)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

        GameObject newBalloon = Instantiate(balloonPrefab, spawnPos, Quaternion.identity);

        // Rastgele bir balon türü seç
        int randomIndex = Random.Range(0, balloonTypes.Count);
        BalloonType selectedType = balloonTypes[randomIndex];

        // Sprite'ý ve skor bilgilerini aktar
        SpriteRenderer sr = newBalloon.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = selectedType.sprite;
        }

        Balloon balloonScript = newBalloon.GetComponent<Balloon>();
        if (balloonScript != null)
        {
            balloonScript.scoreValue = selectedType.score;
            balloonScript.colorName = selectedType.name;
        }
    }
}
