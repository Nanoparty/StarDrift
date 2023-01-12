using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float attackRange;
    [SerializeField] private GameObject coin;
    [SerializeField] private int maxCoins;
    [SerializeField] private int minCoins;
    [SerializeField] private float coinForce;

    private GameObject player;

    private new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);

        Vector3 direction2 = GetDirection();
        if (rigidbody.velocity.magnitude < maxVelocity)
        {
            rigidbody.AddForceAtPosition(direction2 * movementSpeed * Time.deltaTime, transform.position);
        }
    }

    void FireLaser()
    {
        if (canFirePrimary)
        {
            StartCoroutine(FirePrimary());
            canFirePrimary = false;
        }
    }

    void DropCoins()
    {
        int num = Random.Range(minCoins, maxCoins);
        for(int i = 0; i < num; i++)
        {
            GameObject coinObject = Instantiate(coin, transform.position, Quaternion.identity);
            int x = Random.Range(-100, 100);
            int y = Random.Range(-100, 100);
            Vector2 dir = new Vector2(x, y);
            dir.Normalize();
            coinObject.GetComponent<Rigidbody2D>().AddForce(dir * coinForce);
        }
    }

    void HandleDeath()
    {
        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            DropCoins();
            Destroy(gameObject);
        }
    }
}
