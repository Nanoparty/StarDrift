using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject
{
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected float fireDelay;
    [SerializeField] protected GameObject projectile;

    public virtual void Fire(Ship s, int aimVariation, List<string> tags) {
        Debug.Log("Fire Defalt");
    }

    public float GetFireDelay()
    {
        return fireDelay;
    }

    public Sprite GetIcon()
    {
        return Icon;
    }
}
