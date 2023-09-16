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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
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
}
