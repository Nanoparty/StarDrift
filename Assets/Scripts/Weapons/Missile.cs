using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Projectile
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float lifespan;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(lifespan);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected override void Update()
    {
        if (targetTags == null || targetTags.Count == 0) return;

        string tag = targetTags[0];
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        GameObject target = GetNearest(enemies);

        if (target == null)
        {
            transform.position += GetDirection() * speed * Time.deltaTime;
            return;
        }

        Vector3 direction = (target.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

        Vector3 direction2 = direction;
        if (GetComponent<Rigidbody2D>().velocity.magnitude < maxVelocity)
        {
            GetComponent<Rigidbody2D>().AddForceAtPosition(direction2 * speed * Time.deltaTime, transform.position);
        }

        direction = GetDirection();

        if (direction != null)
            transform.position += direction * speed * Time.deltaTime;
    }

    private GameObject GetNearest(GameObject[] enemies)
    {
        GameObject closest = null;
        float minDistance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }
        return closest;
    }

    public Vector3 GetDirection()
    {
        float radians = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTags.Contains(collision.tag))
        {
            collision.GetComponent<Ship>().TakeDamage(damage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
