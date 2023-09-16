using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float maxFireStayTime;
    public float minFireStayTime;

    private void Start()
    {
        Destroy(this.gameObject, Random.Range(minFireStayTime, maxFireStayTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sheep" || collision.gameObject.tag == "snake")
        {
            collision.gameObject.GetComponent<SheepBehaviour>().KillSheep();
        }

    }
}
