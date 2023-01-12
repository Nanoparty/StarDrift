using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScatterGun", menuName = "ScriptableObjects/ScatterGun")]
public class ScatterGun : Weapon
{
    public override void Fire(Ship s, int aimVariation, List<string> tags)
    {
        GameObject laser1 = Instantiate(projectile, s.transform.position, s.transform.rotation);
        GameObject laser2 = Instantiate(projectile, s.transform.position, s.transform.rotation);
        GameObject laser3 = Instantiate(projectile, s.transform.position, s.transform.rotation);
        laser1.GetComponent<Projectile>().SetTags(tags);
        laser2.GetComponent<Projectile>().SetTags(tags);
        laser3.GetComponent<Projectile>().SetTags(tags);
        laser1.GetComponent<Projectile>().SetDirection(s.GetDirectionWithFixedOffset(15));
        laser2.GetComponent<Projectile>().SetDirection(s.GetDirectionWithFixedOffset(-15));
        laser3.GetComponent<Projectile>().SetDirection(s.GetDirection());
    }

}
