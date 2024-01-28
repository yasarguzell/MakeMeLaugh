using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Spawn edilecek objelerin dizisi
    public Transform[] spawnPoints; // Spawn noktalarının dizisi

    void Start()
    {
        InvokeRepeating("SpawnAndDestroy", 0f, 1f); // Belirli aralıklarla SpawnAndDestroy metodunu çağır
    }

    void SpawnAndDestroy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length); // Rastgele bir spawn noktası seç
        Transform spawnPoint = spawnPoints[randomIndex];

        int randomObjectIndex = Random.Range(0, objectsToSpawn.Length); // Rastgele bir obje seç
        GameObject objectToSpawn = objectsToSpawn[randomObjectIndex];

        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity); // Objeyi spawn et
        Destroy(spawnedObject, 1f); // 1 saniye sonra spawn edilen objeyi yok et
    }
}
