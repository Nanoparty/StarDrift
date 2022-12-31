using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float fireDelay;
    [SerializeField] private float health;

    [SerializeField] private new GameObject camera;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject enemyArrow;

    private bool canFire = true;
    
    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        SpawnArrows();
    }

    void Update()
    {
        HandleMovement();
        HandleWeapons();
        HandleDeath();
    }

    void FixedUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    void SpawnArrows()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in enemies)
        {
            GameObject arrow = Instantiate(enemyArrow, transform.position, Quaternion.identity);
            arrow.transform.parent = transform;
            arrow.GetComponent<EnemyTracker>().SetEnemy(e);
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            Vector3 direction = GetDirection();
            if (rigidbody.velocity.magnitude < maxVelocity)
            {
                rigidbody.AddForceAtPosition(direction * movementSpeed * Time.deltaTime, transform.position);
            }
        }
    }

    void HandleWeapons()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canFire)
            {
                StartCoroutine(FireLaser());
                canFire = false;
            }
        }
    }

    void HandleDeath()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator FireLaser()
    {
        GameObject laser = Instantiate(projectile, transform.position, transform.rotation);
        laser.GetComponent<LaserShot>().SetDirection(GetDirection());
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    Vector3 GetDirection()
    {
        float radians = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
