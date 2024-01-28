using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnAreaWidth = 10f; 
    public float spawnAreaHeight = 10f; 

    void Start()
    {
        InvokeRepeating("SpawnObject", 0f, 1f); // 0 saniye bekle, sonra her 1 saniyede bir çağır
    }

    void SpawnObject()
    {
        // Rastgele bir konum oluştur
        float randomX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
        float randomY = Random.Range(spawnAreaHeight / 2f, spawnAreaHeight * 2f);

        // Nesneyi spawn et
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
