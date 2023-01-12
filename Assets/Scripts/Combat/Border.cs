using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public bool horizontal;
    public bool vertical;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        if (horizontal) vel.y *= -1;
        if (vertical) vel.x *= -1;
        
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
    }
}
