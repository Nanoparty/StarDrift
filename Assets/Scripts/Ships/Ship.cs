using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float boostSpeed;
    [SerializeField] protected float boostCooldown;
    [SerializeField] protected float maxVelocity;
    [SerializeField] protected float fireDelay;
    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected int aimVariation;

    [SerializeField] protected GameObject explosion;
    [SerializeField] protected Weapon primaryWeapon;
    [SerializeField] protected Weapon secondaryWeapon;

    [SerializeField] protected bool canFirePrimary = true;
    [SerializeField] protected bool canFireSecondary = true;
    [SerializeField] protected bool canBoost = true;
    [SerializeField] protected List<string> enemyTags;

    protected new Rigidbody2D rigidbody;
    protected CombatManager cm;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cm = GameObject.Find("CombatManager").GetComponent<CombatManager>();
    }

    protected IEnumerator FirePrimary()
    {
        primaryWeapon.Fire(this, aimVariation, enemyTags);
        yield return new WaitForSeconds(primaryWeapon.GetFireDelay());
        canFirePrimary = true;
    }

    protected IEnumerator FireSecondary()
    {
        secondaryWeapon.Fire(this, aimVariation, enemyTags);
        yield return new WaitForSeconds(secondaryWeapon.GetFireDelay());
        canFireSecondary = true;
    }

    protected IEnumerator FireBoost()
    {
        Vector3 direction = GetDirection();
        rigidbody.AddForceAtPosition(direction * boostSpeed * Time.deltaTime, transform.position);
        yield return new WaitForSeconds(boostCooldown);
        canBoost = true;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
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

    public Vector3 GetDirectionVariable(int maxVariation)
    {
        int offset = Random.Range(-maxVariation, maxVariation);
        float radians = (transform.eulerAngles.z + 90 + offset) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);

        Vector3 direction = new Vector3(x, y, 0).normalized;
        return direction;
    }

    public float Vector3ToAngle(Vector3 vector)
    {
        float angle = Mathf.Atan2(vector.y, vector.x);

        return angle * Mathf.Rad2Deg;
    }

    

}
