using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxHandler : MonoBehaviour
{
    Vector2 endPos;
    Vector2 startPos;
    float t;
    public float timeToReachGround;
    public GameObject[] spawnableObjects;

    public GameObject dustCloud;

    private void Awake()
    {
        endPos = transform.position;
        startPos.x = endPos.x;
        startPos.y = 10;
    }
    private void Update()
    {
        t += Time.deltaTime;
        transform.position = Vector2.Lerp(startPos, endPos, t / timeToReachGround);
        if (t >= timeToReachGround)
        {
            OpenBox();
        }
    }
    public void OpenBox()
    {
        Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], transform.position, Quaternion.identity);
        Instantiate(dustCloud, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
