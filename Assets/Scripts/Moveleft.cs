using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    public float speed = 13;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2((float)Random.Range(-1000, 1000), (float)Random.Range(-1000, 1000)).normalized;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed;
    }
}
