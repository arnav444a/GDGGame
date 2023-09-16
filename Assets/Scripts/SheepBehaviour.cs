using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    public float sprintSpeed;
    public float speed;
    public float cappedDistance = 9;
    Rigidbody2D rb;
    float forceMultiplier;

    public bool fireSheep;
    public GameObject fire;
    public Transform sprite;

    public Vector3 oldPos;

    public AudioSource deathNoise;
    bool canIdle = true;

    public float minIdleTime = 2;
    public float maxIdleTime = 2;
    public float minMoveTime = 3;
    public float maxMoveTime = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(gameObject.tag == "sheep")
        {
            SpawnerScript.sheepCount += 1;
            print(SpawnerScript.sheepCount);
        }

        if (fireSheep)
        {
                oldPos = transform.position;
                InvokeRepeating("SpawnFire", 0.5f, 0.5f);
        }
    }

   
    private void Update()
    {
        if (rb.velocity.x < 0)
        {
            sprite.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if(rb.velocity.x > 0)
        {
            sprite.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 worldPosition = new Vector2(Worldpos.x, Worldpos.y);
        Vector2 directionToEntity = ((Vector2)transform.position - worldPosition);
        Vector2 direction = directionToEntity;
        float currentDistance = directionToEntity.magnitude;
        forceMultiplier = Mathf.Lerp(sprintSpeed, speed, currentDistance/cappedDistance);
        if (directionToEntity.magnitude < cappedDistance)
        {
            rb.velocity = directionToEntity.normalized * forceMultiplier;
            canIdle = true;
            StopAllCoroutines();
        }
        else
        {
            if (canIdle)
            {
                StartCoroutine(IdleSheep());
            }
        }
    }
    public void SpawnFire()
    {
        Instantiate(fire, oldPos, Quaternion.identity);
        oldPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "snake" && gameObject.tag != "snake")
        {
            KillSheep();
        }
        if(collision.gameObject.tag == "car")
        {
            KillSheep();
        }
    }
    public void KillSheep()
    {
        deathNoise.Play();
        if (gameObject.tag == "sheep" )
        {
            SpawnerScript.sheepCount -= 1;
        }
        CameraShake.instance.ShakeSmall();
        Destroy(this.gameObject, 0.2f);
    }
    public IEnumerator IdleSheep()
    {
        canIdle = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(Random.Range(minIdleTime,maxIdleTime));
        Vector2 direction = new Vector2((float)Random.Range(-1000, 1000), (float)Random.Range(-1000, 1000)).normalized;
        rb.velocity = direction * speed;
        yield return new WaitForSeconds(Random.Range(minMoveTime, maxMoveTime));
        canIdle = true;
        rb.velocity = Vector2.zero;
    }
}
