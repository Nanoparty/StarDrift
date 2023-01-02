using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected List<string> targetTags;

    protected Vector3 direction;

    public void SetDirection(Vector3 d)
    {
        direction = d;
    }

    protected void Update()
    {
        if (direction != null)
            transform.position += direction * speed * Time.deltaTime;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTags.Contains(collision.tag))
        {

            if (collision.GetComponent<Enemy>() != null)
            {
                collision.GetComponent<Enemy>().TakeDamage(damage);
            }

            if (collision.GetComponent<Player>() != null)
            {
                collision.GetComponent<Player>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
