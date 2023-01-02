using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    [SerializeField] protected Sprite Icon;
    [SerializeField] protected float fireDelay;
    [SerializeField] protected GameObject projectile;

    protected bool canFire;

    public abstract void Fire();
}
