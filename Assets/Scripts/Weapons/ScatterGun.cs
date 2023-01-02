using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScatterGun", menuName = "ScriptableObjects/ScatterGun")]
public class ScatterGun : Weapon
{
    public override void Fire(Player p)
    {
        GameObject laser1 = Instantiate(projectile, p.transform.position, p.transform.rotation);
        GameObject laser2 = Instantiate(projectile, p.transform.position, p.transform.rotation);
        GameObject laser3 = Instantiate(projectile, p.transform.position, p.transform.rotation);
        laser1.GetComponent<LaserShot>().SetDirection(p.GetDirectionWithFixedOffset(15));
        laser2.GetComponent<LaserShot>().SetDirection(p.GetDirectionWithFixedOffset(-15));
        laser3.GetComponent<LaserShot>().SetDirection(p.GetDirection());
    }

}
