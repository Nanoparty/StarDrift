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

}
