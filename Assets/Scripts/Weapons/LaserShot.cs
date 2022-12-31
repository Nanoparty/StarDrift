using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private List<string> targetTags;

    private Vector3 direction;

    public void SetDirection(Vector3 d)
    {
        direction = d;
    }

    void Update()
    {
        if (direction != null)
            transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTags.Contains(collision.tag)){

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
