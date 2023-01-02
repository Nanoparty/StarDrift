using System;
using UnityEngine;

public class PlanetData : MonoBehaviour
{
    public static PlanetData pd;

    public GameObject Terra_1;
    public GameObject Terra_2;
    public GameObject Barren_1;
    public GameObject Barren_2;
    public GameObject Barren_3;
    public GameObject Barren_4;
    public GameObject Ice;
    public GameObject Ocean;
    public GameObject Gas_1;
    public GameObject Gas_2;
    public GameObject Gas_3;
    public GameObject Gas_4;
    public GameObject Lava_1;
    public GameObject Lava_2;
    public GameObject Lava_3;
    public GameObject Forest;
    public GameObject Jungle;

    private void Awake()
    {
        if (pd == null)
        {
            pd = this;
        }
        else if (pd != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public GameObject GetRandomPlanet()
    {
        GameObject Planet = null;
        int random = UnityEngine.Random.Range(0, 17);
        if (random == 0) Planet = Terra_1;
        if (random == 1) Planet = Terra_2;
        if (random == 2) Planet = Barren_1;
        if (random == 3) Planet = Barren_2;
        if (random == 4) Planet = Barren_3;
        if (random == 5) Planet = Barren_4;
        if (random == 6) Planet = Ice;
        if (random == 7) Planet = Ocean;
        if (random == 8) Planet = Gas_1;
        if (random == 9) Planet = Gas_2;
        if (random == 10) Planet = Gas_3;
        if (random == 11) Planet = Gas_4;
        if (random == 12) Planet = Lava_1;
        if (random == 13) Planet = Lava_2;
        if (random == 14) Planet = Lava_3;
        if (random == 15) Planet = Forest;
        if (random == 16) Planet = Jungle;

        if (Planet == null) Planet = Terra_1;
        return Planet;
    }

    public enum PlanetType
    {
        Terra1,
        Terra2,
        Barren1,
        Barren2,
        Barren3,
        Barren4,
        Ice,
        Ocean,
        Gas1,
        Gas2,
        Gas3,
        Gas4,
        Lava1,
        Lava2,
        Lava3,
        Forest,
        Jungle
    }

    public PlanetType GetRandomPlanetType()
    {
        Array values = Enum.GetValues(typeof(PlanetType));
        PlanetType type = (PlanetType)values.GetValue(UnityEngine.Random.Range(0,values.Length));
        return type;
    }

    public GameObject GetPlanetPrefab(PlanetType type)
    {
        GameObject Planet = null;
        if (type == PlanetType.Terra1) Planet = Terra_1;
        if (type == PlanetType.Terra2) Planet = Terra_2;
        if (type == PlanetType.Barren1) Planet = Barren_1;
        if (type == PlanetType.Barren2) Planet = Barren_2;
        if (type == PlanetType.Barren3) Planet = Barren_3;
        if (type == PlanetType.Barren4) Planet = Barren_4;
        if (type == PlanetType.Ice) Planet = Ice;
        if (type == PlanetType.Ocean) Planet = Ocean;
        if (type == PlanetType.Gas1) Planet = Gas_1;
        if (type == PlanetType.Gas2) Planet = Gas_2;
        if (type == PlanetType.Gas3) Planet = Gas_3;
        if (type == PlanetType.Gas4) Planet = Gas_4;
        if (type == PlanetType.Lava1) Planet = Lava_1;
        if (type == PlanetType.Lava2) Planet = Lava_2;
        if (type == PlanetType.Lava3) Planet = Lava_3;
        if (type == PlanetType.Forest) Planet = Forest;
        if (type == PlanetType.Jungle) Planet = Jungle;

        if (Planet == null) Planet = Terra_1;
        return Planet;
    }
}
