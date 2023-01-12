using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NinjaStarLauncher", menuName = "ScriptableObjects/NinjaStarLauncher")]

public class NinjaStarLauncher : Weapon
{
    public override void Fire(Ship s, int aimVariation, List<string> tags)
    {
        GameObject laser = Instantiate(projectile, s.transform.position, s.transform.localRotation);
        laser.GetComponent<Projectile>().SetTags(tags);
        laser.GetComponent<Projectile>().SetDirection(s.GetDirectionVariable(aimVariation));
    }
}
