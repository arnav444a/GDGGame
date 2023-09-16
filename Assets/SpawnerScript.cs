using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public BoxCollider2D collider;
    public GameObject prefab;
    float time;
    public float delayToSpawn = 5;

    public float maxDelay;
    public float minDelay;
    public float maxDelayTime;

    public int spawnAmount = 1;

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = delayToSpawn;
            for(int i = 0; i < spawnAmount;i++)
            {
                SpawnObject();
            }
            
        }
    }
    public void SpawnObject()
    {
        float xDist = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
        float yDist = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
        GameObject spawnedObj = Instantiate<GameObject>(prefab, new Vector3(xDist, yDist, 0), Quaternion.identity);
    }
    public void IncreaseDelay()
    {
        Mathf.Lerp(minDelay, maxDelay, maxDelayTime / Time.time);
    }
}
