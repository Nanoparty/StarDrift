using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float health;
    [SerializeField] private float attackRange;
    [SerializeField] private float fireDelay;

    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask playerLayer;

    private bool canFire = true;

    private GameObject player;
    private new Rigidbody2D rigidbody;
    private CombatManager cm;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody2D>();
        cm = GameObject.Find("CombatManager").GetComponent<CombatManager>();
    }

    void Update()
    {
        if (player == null) return;
        if (!cm.isStarted) return;

        HandleMovement();
        HandleDeath();
        
    }

    void FixedUpdate()
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];
        RaycastHit2D hit = Physics2D.Raycast(transform.position, GetDirection(), attackRange, playerLayer);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                FireLaser();
            }
        }
    }

    void HandleMovement()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

        // Rotate the object to face the player
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

        Vector3 direction2 = GetDirection();
        if (rigidbody.velocity.magnitude < maxVelocity)
        {
            rigidbody.AddForceAtPosition(direction2 * movementSpeed * Time.deltaTime, transform.position);
        }

        //Debug.Log("Target Angle:" + angle + "\nCurrent Angle:" + transform.eulerAngles.z);
    }

    void FireLaser()
    {
        if (canFire)
        {
            canFire = false;
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        GameObject shot = Instantiate(projectile, transform.position, transform.rotation);
        shot.GetComponent<LaserShot>().SetDirection(GetDirection(15));
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    void HandleDeath()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public float Vector3ToAngle(Vector3 vector)
    {
        // Calculate the angle in radians
        float angle = Mathf.Atan2(vector.y, vector.x);

        // Convert radians to degrees and return the result
        return angle * Mathf.Rad2Deg;
    }

    Vector3 GetDirection()
    {
        float radians = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    Vector3 GetDirection(int maxVariation)
    {
        int offset = Random.Range(-maxVariation, maxVariation);
        float radians = (transform.eulerAngles.z + 90 + offset) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }
}
