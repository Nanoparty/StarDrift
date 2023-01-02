using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float fireDelay;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    [SerializeField] private new GameObject camera;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject enemyArrow;
    [SerializeField] private Weapon primaryWeapon;

    private List<GameObject> enemyArrows;

    [SerializeField] private bool canFire = true;
    
    private new Rigidbody2D rigidbody;
    private Slider hpSlider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
        HandleMovement();
        HandleWeapons();
        HandleDeath();
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
        foreach(GameObject e in enemies)
        {
            GameObject arrow = Instantiate(enemyArrow, transform.position, Quaternion.identity);
            arrow.transform.parent = transform;
            arrow.GetComponent<EnemyTracker>().SetEnemy(e);
            enemyArrows.Add(arrow);
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
                StartCoroutine(FirePrimary());
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

    IEnumerator FirePrimary()
    {
        primaryWeapon.Fire(this);
        yield return new WaitForSeconds(primaryWeapon.GetFireDelay());
        canFire = true;
    }

    public Vector3 GetDirection()
    {
        float radians = (transform.eulerAngles.z + 90) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    public Vector3 GetDirectionWithFixedOffset(int degrees)
    {
        float radians = (transform.eulerAngles.z + 90 + degrees) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hpSlider.value = health;
    }
}
