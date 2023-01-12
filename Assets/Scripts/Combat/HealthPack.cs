using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().AddHealth(5);
            Destroy(gameObject);
        }

        if (collision.GetComponent<Border>() != null)
        {
            Vector2 dir = GetComponent<Rigidbody2D>().velocity;
            if (collision.GetComponent<Border>().horizontal)
            {
                dir.y *= -1;
            }
            if (collision.GetComponent<Border>().vertical)
            {
                dir.x *= -1;
            }
            GetComponent<Rigidbody2D>().velocity = dir;
        }

    }
}
