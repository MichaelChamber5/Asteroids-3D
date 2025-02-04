using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject ship;

    [SerializeField] GameObject meteor;
    [SerializeField] int maxMeteors;

    [SerializeField] float minSpawnDistance;
    [SerializeField] float maxSpawnDistance;

    [SerializeField] float minSize;
    [SerializeField] float maxSize;

    float percentAllowed = 0.1f;

    ObjectPool pool;

    private void Start()
    {
        pool = new ObjectPool(meteor, maxMeteors);
        for(int i = 0; i < pool.Size(); i++)
        {
            SpawnMeteor();
        }
    }

    private void FixedUpdate()
    {
        if(ship != null && pool.NumActive() < (pool.Size() - (pool.Size() * percentAllowed)))
        {
            SpawnMeteor();
        }
    }

    private void SpawnMeteor()
    {
        GameObject temp = pool.GetObject();

        // Generate a random direction
        Vector3 randomDirection = Random.insideUnitSphere.normalized;

        // Random distance within the min-max range
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Calculate final spawn position
        Vector3 spawnPosition = ship.transform.position + randomDirection * distance;

        float size = Random.Range(minSize, maxSize);

        temp.transform.position = spawnPosition;
        temp.transform.localScale = new Vector3(size, size, size);
        temp.SetActive(true);
    }

    private int NegPos()
    {
        int num = Random.Range(0, 2);
        if(num == 0)
            return -1;
        return 1;
    }

    public float GetDespawnRange()
    {
        return maxSpawnDistance;
    }
}
