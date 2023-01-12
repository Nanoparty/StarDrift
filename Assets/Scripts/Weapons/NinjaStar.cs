using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : Projectile
{
    [SerializeField] private float rotationSpeed;
    protected override void Update()
    {
        Vector3 target = new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        //transform.Rotate(target);
        transform.position += transform.TransformDirection(transform.TransformDirection(1,1,0) * speed * Time.deltaTime);
    }

    public Vector3 GetDirectionWithFixedOffset(int degrees)
    {
        float radians = (transform.eulerAngles.z + 90 + degrees) * Mathf.Deg2Rad;

        float x = Mathf.Cos(radians);
        float y = Mathf.Sin(radians);
        float z = transform.TransformDirection(Vector3.forward).z;

        Vector3 direction = new Vector3(x, y, z).normalized;
        return direction;
    }
}
