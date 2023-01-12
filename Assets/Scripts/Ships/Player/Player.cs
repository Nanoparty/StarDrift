using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Ship
{
    [SerializeField] private new GameObject camera;
    [SerializeField] private GameObject enemyArrow;
    [SerializeField] private float coinRange;
    [SerializeField] private LayerMask coinLayer;
    [SerializeField] private float coinForce;

    private List<GameObject> enemyArrows;

    private Slider hpSlider;
    private int coins;

    private new void Awake()
    {
        base.Awake();
        enemyArrows = new List<GameObject>();
        hpSlider = GameObject.FindGameObjectWithTag("HP").GetComponent<Slider>();
    }

    void Start()
    {
        SpawnArrows();

        hpSlider.maxValue = maxHealth;
        hpSlider.minValue = 0;
        hpSlider.value = health;
    }

    void Update()
    {
        if (!cm.isStarted) return;

        HandleMovement();
        HandleWeapons();
        HandleDeath();
        PickupCoins();
    }

    void FixedUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    public void SpawnArrows()
    {
        foreach (GameObject o in enemyArrows)
        {
            Destroy(o);
        }
        enemyArrows.Clear();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
        {
            GameObject arrow = Instantiate(enemyArrow, transform.position, Quaternion.identity);
            arrow.transform.parent = transform;
            arrow.GetComponent<EnemyTracker>().SetEnemy(e);
            enemyArrows.Add(arrow);
        }
    }

    void PickupCoins()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.CircleCastAll(transform.position, coinRange, Vector2.one, 0f, coinLayer);

        foreach (RaycastHit2D hit in hits)
        {
            Vector2 force = new Vector2(transform.position.x, transform.position.y)- hit.point;
            hit.rigidbody.AddForce(force * coinForce * Time.deltaTime);
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
            Vector3 force = direction * movementSpeed * Time.deltaTime;

            if (rigidbody.velocity.x > maxVelocity && force.x > 0) force.x = 0;
            if (rigidbody.velocity.x < -maxVelocity && force.x < 0) force.x = 0;

            if (rigidbody.velocity.y > maxVelocity && force.y > 0) force.y = 0;
            if (rigidbody.velocity.y < -maxVelocity && force.y < 0) force.y = 0;

            rigidbody.AddForceAtPosition(force, transform.position);

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Shift");
            if (canBoost)
            {
                Debug.Log("Boost");
                StartCoroutine(FireBoost());
                canBoost = false;
            }
        }
    }

    void HandleWeapons()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canFirePrimary)
            {
                StartCoroutine(FirePrimary());
                canFirePrimary = false;
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

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        hpSlider.value = health;
    }

    public void AddCoins(int c)
    {
        coins += c;
    }
}
