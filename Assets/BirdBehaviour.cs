using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    bool fire;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "snake")
        {
            BirdDie();

        }
        if( collision.gameObject.tag == "fire")
        {
            fire = true;
        }
    }
    private void Update()
    {
        if (fire)
        {

        }
    }

    public void BirdDie()
    {
        Destroy(this.gameObject);
    }
}
