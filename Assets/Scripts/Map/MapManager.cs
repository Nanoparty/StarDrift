using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> planets;
    [SerializeField] private List<GameObject> nextPlanets;
    [SerializeField] private List<GameObject> visitedPlanets;
    [SerializeField] private GameObject firstPlanet;

    public bool InfoOpen = false;

    private GameObject currentPlanet;

    private void Start()
    {
        if (planets == null) planets = new List<GameObject>();
        if (nextPlanets == null) nextPlanets = new List<GameObject>();
        if (visitedPlanets == null) visitedPlanets = new List<GameObject>();

        if (currentPlanet == null)
        {
            nextPlanets.Add(firstPlanet);
            firstPlanet.GetComponent<PlanetNode>().SetStatus("Next");
            UpdateActivePlanets();
        }

        if (Data.loadData == false)
        {
            foreach( GameObject p in planets)
            {
                p.GetComponent<PlanetNode>().Create();
            }
            Data.loadData = true;
        }
        else
        {
            planets = Data.planets;
            nextPlanets = Data.nextPlanets;
            visitedPlanets = Data.visitedPlanets;
            currentPlanet = Data.currentPlanet;
            UpdateActivePlanets();
        }

        Data.planets = planets;
        Data.nextPlanets = nextPlanets;
        Data.visitedPlanets = visitedPlanets;
        Data.currentPlanet = currentPlanet;
    }

    private void Update()
    {

    }

    private void UpdateActivePlanets()
    {
        GameObject outline = null;
        foreach (GameObject o in planets)
        {
            outline = o.transform.Find("Outline").gameObject;
            outline.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("Visited Planets: " + visitedPlanets);
        foreach (GameObject o in visitedPlanets)
        {
            outline = o.transform.Find("Outline").gameObject;
            outline.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        foreach (GameObject o in nextPlanets)
        {
            outline = o.transform.Find("Outline").gameObject;
            outline.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (currentPlanet != null)
        {
            outline = currentPlanet.transform.Find("Outline").gameObject;
            outline.GetComponent<SpriteRenderer>().color = Color.magenta;
        }

        Data.nextPlanets = nextPlanets;
        Data.visitedPlanets = visitedPlanets;
        Data.currentPlanet = currentPlanet;

    }

    public void SetCurrentPlanet(PlanetNode planet)
    {
        if (currentPlanet != null)
        {
            visitedPlanets.Add(currentPlanet);
        }
        
        currentPlanet = planet.gameObject;
        nextPlanets.Clear();
        nextPlanets.AddRange(planet.GetNextPlanets());
        UpdateActivePlanets();
    }

    public bool IsNext(GameObject o)
    {
        return nextPlanets.Contains(o);
    }

}
