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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
    public void KillSheep()
    {
        CameraShake.instance.ShakeSmall();
        Destroy(this.gameObject);
    }
}
