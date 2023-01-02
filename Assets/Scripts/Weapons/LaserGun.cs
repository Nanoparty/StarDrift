using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaserGun", menuName = "ScriptableObjects/LaserGun")]
public class LaserGun : Weapon
{
    public override void Fire(Player p)
    {
        Debug.Log("Fire");
        GameObject laser = Instantiate(projectile, p.transform.position, p.transform.rotation);
        laser.GetComponent<LaserShot>().SetDirection(p.GetDirection());
    }
    
}
