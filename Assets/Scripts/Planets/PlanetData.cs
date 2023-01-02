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
        int random = Random.Range(0, 17);
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
}
