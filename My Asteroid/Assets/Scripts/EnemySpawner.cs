using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1;

    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + (60 / spawnRatePerMinute);
            spawnRatePerMinute += spawnRateIncrement;

            float RandX = Random.Range(-6, 6);

            var spawnPosition = new Vector2(RandX, transform.position.y);

            Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        }
       
    }
}
