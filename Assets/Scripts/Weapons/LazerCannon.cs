using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LazerCannon", menuName = "ScriptableObjects/LazerCannon")]
public class LazerCannon : Weapon
{
    public override void Fire(Ship s, int aimVariation, List<string> tags)
    {
        Debug.Log("Fire");
        GameObject laser = Instantiate(projectile, s.transform.position, s.transform.rotation);
        laser.GetComponent<Projectile>().SetTags(tags);
        laser.GetComponent<Projectile>().SetDirection(s.GetDirectionVariable(aimVariation));
    }
}
