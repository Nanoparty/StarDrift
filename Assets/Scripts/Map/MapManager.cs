using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PlanetData;

public class MapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> planets;
    [SerializeField] private List<int> nextPlanets;
    [SerializeField] private List<int> visitedPlanets;
    [SerializeField] private GameObject firstPlanet;

    public List<PlanetData> planetData;

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

    public Sprite Terra_1_sprite;
    public Sprite Terra_2_sprite;
    public Sprite Barren_1_sprite;
    public Sprite Barren_2_sprite;
    public Sprite Barren_3_sprite;
    public Sprite Barren_4_sprite;
    public Sprite Ice_sprite;
    public Sprite Ocean_sprite;
    public Sprite Gas_1_sprite;
    public Sprite Gas_2_sprite;
    public Sprite Gas_3_sprite;
    public Sprite Gas_4_sprite;
    public Sprite Lava_1_sprite;
    public Sprite Lava_2_sprite;
    public Sprite Lava_3_sprite;
    public Sprite Forest_sprite;
    public Sprite Jungle_sprite;

    public bool InfoOpen = false;

    private int currentPlanet;

    private void Start()
    {
        currentPlanet = Data.currentPlanet;
        nextPlanets = Data.nextPlanets ?? new List<int>();
        visitedPlanets = Data.visitedPlanets ?? new List<int>();

        if (Data.planetData == null)
        {
            GeneratePlanetData();
        }else
        {
            planetData = Data.planetData;
        }

        PopulatePlanetNodes();

        if (currentPlanet == -1)
        {
            nextPlanets.Add(firstPlanet.GetComponent<PlanetNode>().id);
        }

        UpdateActivePlanets();
    }

    private void GeneratePlanetData()
    {
        planetData = new List<PlanetData>();
        for (int i = 0; i < 9; i++)
        {
            System.Array values = System.Enum.GetValues(typeof(PlanetType));
            PlanetType type = (PlanetType)values.GetValue(Random.Range(0, values.Length));
            
            planetData.Add(new PlanetData(i, type));
        }

        Data.planetData = planetData;
    }

    private void Update()
    {

    }

    public void PopulatePlanetNodes()
    {
        foreach (PlanetData data in planetData)
        {
            GameObject planet = planets.Where(p => p.GetComponent<PlanetNode>().id == data.id).First();
            planet.GetComponent<PlanetNode>().planetData = data;
            planet.GetComponent<PlanetNode>().Create();
        }
    }

    private void UpdateActivePlanets()
    {
        foreach (GameObject o in planets)
        {
            int id = o.GetComponent<PlanetNode>().id;
            GameObject outline = o.transform.Find("Outline").gameObject;
            outline.GetComponent<SpriteRenderer>().color = Color.white;

            if (visitedPlanets.Contains(id))
            {
                outline.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            if (nextPlanets.Contains(id))
            {
                outline.GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (currentPlanet == id)
            {
                outline.GetComponent<SpriteRenderer>().color = Color.magenta;
            }

        }
        

        //Data.nextPlanets = nextPlanets;
        //Data.visitedPlanets = visitedPlanets;
        //Data.currentPlanet = currentPlanet;

    }

    public void SetCurrentPlanet(int id)
    {
        if (currentPlanet != -1)
        {
            visitedPlanets.Add(currentPlanet);
        }
        
        nextPlanets.Clear();

        currentPlanet = id;

        GameObject current = planets.Where(p => p.GetComponent<PlanetNode>().id == currentPlanet).First();
        List<GameObject> next = current.GetComponent<PlanetNode>().GetNextPlanets();
        foreach (GameObject o in next)
        {
            nextPlanets.Add(o.GetComponent<PlanetNode>().id);
        }

        UpdateActivePlanets();
    }

    public bool IsNext(int id)
    {
        return nextPlanets.Contains(id);
    }

    public void SaveNodes()
    {
        Data.currentPlanet = currentPlanet;
        Data.nextPlanets = nextPlanets;
        Data.visitedPlanets = visitedPlanets;
    }

    

    public PlanetType GetRandomPlanetType()
    {
        System.Array values = System.Enum.GetValues(typeof(PlanetType));
        PlanetType type = (PlanetType)values.GetValue(UnityEngine.Random.Range(0, values.Length));
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

    public Sprite GetPlanetSprite(PlanetType type)
    {
        Sprite Planet = null;
        if (type == PlanetType.Terra1) Planet = Terra_1_sprite;
        if (type == PlanetType.Terra2) Planet = Terra_2_sprite;
        if (type == PlanetType.Barren1) Planet = Barren_1_sprite;
        if (type == PlanetType.Barren2) Planet = Barren_2_sprite;
        if (type == PlanetType.Barren3) Planet = Barren_3_sprite;
        if (type == PlanetType.Barren4) Planet = Barren_4_sprite;
        if (type == PlanetType.Ice) Planet = Ice_sprite;
        if (type == PlanetType.Ocean) Planet = Ocean_sprite;
        if (type == PlanetType.Gas1) Planet = Gas_1_sprite;
        if (type == PlanetType.Gas2) Planet = Gas_2_sprite;
        if (type == PlanetType.Gas3) Planet = Gas_3_sprite;
        if (type == PlanetType.Gas4) Planet = Gas_4_sprite;
        if (type == PlanetType.Lava1) Planet = Lava_1_sprite;
        if (type == PlanetType.Lava2) Planet = Lava_2_sprite;
        if (type == PlanetType.Lava3) Planet = Lava_3_sprite;
        if (type == PlanetType.Forest) Planet = Forest_sprite;
        if (type == PlanetType.Jungle) Planet = Jungle_sprite;

        if (Planet == null) Planet = Terra_1_sprite;
        return Planet;
    }

    public string GetPlanetEnvironment(PlanetType type)
    {
        string Planet = "";
        if (type == PlanetType.Terra1) Planet = "Terran";
        if (type == PlanetType.Terra2) Planet = "Dead Terran";
        if (type == PlanetType.Barren1) Planet = "Barren";
        if (type == PlanetType.Barren2) Planet = "Barren";
        if (type == PlanetType.Barren3) Planet = "Barren";
        if (type == PlanetType.Barren4) Planet = "Barren";
        if (type == PlanetType.Ice) Planet = "Tundra";
        if (type == PlanetType.Ocean) Planet = "Oceanic";
        if (type == PlanetType.Gas1) Planet = "Gas Giant";
        if (type == PlanetType.Gas2) Planet = "Gas Giant";
        if (type == PlanetType.Gas3) Planet = "Gas Giant";
        if (type == PlanetType.Gas4) Planet = "Gas Giant";
        if (type == PlanetType.Lava1) Planet = "Volcanic";
        if (type == PlanetType.Lava2) Planet = "Volcanic";
        if (type == PlanetType.Lava3) Planet = "Volcanic";
        if (type == PlanetType.Forest) Planet = "Temporate Forest";
        if (type == PlanetType.Jungle) Planet = "Tropical Forest";

        if (Planet == null) Planet = "Unknown";
        return Planet;
    }

}
