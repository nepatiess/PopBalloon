using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public float spawnTime = 1f;
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = -5f;


    private void Start()
    {
        StartCoroutine(SpawnBalloons());
    }

    IEnumerator SpawnBalloons()
    {
        while (true)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnBalloon()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);
        Instantiate(balloonPrefab, spawnPos, Quaternion.identity);
    }
}
