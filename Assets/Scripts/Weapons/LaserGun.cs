using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    public override void Fire()
    {
        if (canFire)
        {
            //StartCoroutine(FireLaser());
            canFire = false;
        }
    }

    protected IEnumerator SpawnProjectiles()
    {
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    
}
