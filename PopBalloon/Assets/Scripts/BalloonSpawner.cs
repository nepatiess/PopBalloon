using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [System.Serializable]
    public class BalloonType
    {
        public string name;          // "blue", "green", "black"
        public GameObject prefab;    // o renge ait prefab (sprite + animator dahil)
        public int score;            // patlatýldýðýnda verilen puan
    }

    public List<BalloonType> balloonTypes;
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

        int randomIndex = Random.Range(0, balloonTypes.Count);
        BalloonType selectedType = balloonTypes[randomIndex];

        GameObject newBalloon = Instantiate(selectedType.prefab, spawnPos, Quaternion.identity);

        Balloon balloonScript = newBalloon.GetComponent<Balloon>();
        if (balloonScript != null)
        {
            balloonScript.scoreValue = selectedType.score;
            balloonScript.colorName = selectedType.name;
        }
    }
}
