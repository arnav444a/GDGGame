using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public GameObject fire;
    Vector3 oldPos;
    Rigidbody2D rb;
    Vector2 direction;
    Vector2 currentVelocity;
    public float speed = 8;
    Vector2 vel;
    bool fireBird = false;


    public SpriteRenderer renderer;


    IEnumerator FireDeath()
    {
        yield return new WaitForSeconds(3f);
        BirdDie();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.tag == "snake")
        {
            BirdDie();

        }
        if( collision.gameObject.tag == "fire")
        {
            StartCoroutine(FireDeath());
            if (oldPos == null)
            {
                oldPos = transform.position;
                InvokeRepeating("SpawnFire", 0.1f, 0.2f);
            }
        }
        if(collision.gameObject.tag == "NEGborderY")
        {

            rb.velocity = new Vector2(currentVelocity.x, - Mathf.Abs(currentVelocity.y));
        }
        if (collision.gameObject.tag == "borderY")
        {
            rb.velocity = new Vector2(currentVelocity.x,  Mathf.Abs(currentVelocity.y));

        }
        if (collision.gameObject.tag == "NEGborderX")
        {
            rb.velocity = new Vector2(- Mathf.Abs(currentVelocity.x), currentVelocity.y);


        }
        if (collision.gameObject.tag == "borderX")
        {
            rb.velocity = new Vector2(Mathf.Abs(currentVelocity.x), currentVelocity.y);
        }

        currentVelocity = rb.velocity;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2((float)Random.Range(-1000, 1000), (float)Random.Range(-1000, 1000)).normalized;
        rb.velocity = direction * speed;
        currentVelocity = rb.velocity;
    }
    public void BirdDie()
    {
        CameraShake.instance.ShakeSmall();
        Destroy(this.gameObject);
    }
    public void SpawnFire()
    {
        Instantiate(fire, oldPos, Quaternion.identity);
        oldPos = transform.position;
    }
    public void ProduceFire()
    {
        if (fireBird == false)
        {
            fireBird = true;
            renderer.color = Color.red;

            StartCoroutine(FireDeath());
            if (oldPos == null)
            {
                oldPos = transform.position;
            }
            InvokeRepeating("SpawnFire", 0.1f, 0.2f);
        }

    }

}
