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

    public void SetTags(List<string> tags)
    {
        targetTags = tags;
    }

    protected virtual void Update()
    {
        if (direction != null)
            transform.position += direction * speed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTags.Contains(collision.tag))
        {
            collision.GetComponent<Ship>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
