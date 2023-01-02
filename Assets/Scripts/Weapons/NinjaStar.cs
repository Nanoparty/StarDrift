using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private List<string> targetTags;

    private Vector3 direction;

    // Speed at which the object moves
    public float movementSpeed = 1f;

    // Distance between each turn in the spiral
    public float turnDistance = 1f;

    // Rotation speed of the object
    public float rotationSpeed = 90f;

    // Current distance traveled by the object
    private float distanceTraveled = 0f;

    public void SetDirection(Vector3 d)
    {
        direction = d;
    }

    void Update()
    {
        // Calculate the distance traveled this frame
        float distance = movementSpeed * Time.deltaTime;

        // Add the distance traveled to the total distance traveled
        distanceTraveled += distance;

        // If the distance traveled exceeds the turn distance, rotate the object and reset the distance traveled
        if (distanceTraveled > turnDistance)
        {
            distanceTraveled = 0f;
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Move the object forward
        transform.position += new Vector3(1,1,0) * distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
