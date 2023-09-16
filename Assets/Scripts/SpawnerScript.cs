using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerScript : MonoBehaviour
{
    public BoxCollider2D collider;
    public GameObject prefab;
    public GameObject sheep;
    float time;
    public float delayToSpawn = 5;

    public float maxDelay;
    public float minDelay;
    public float maxDelayTime;

    public int spawnAmount = 1;

    public static int sheepCount;


    public void Awake()
    {
        for ( int i = 0; i < 5; i++)
        {
            float xDist = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float yDist = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            GameObject spawnedObj = Instantiate<GameObject>(sheep, new Vector3(xDist, yDist, 0), Quaternion.identity);

        }

    }
    private void Update()
    {
        if (sheepCount <= 0)
        {
            SceneManager.LoadScene(0);
        }
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
