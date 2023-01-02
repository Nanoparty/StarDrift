using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static GameObject PlanetPrefab;
    public static int numEnemies;

    public static List<GameObject> planets;
    public static List<GameObject> visitedPlanets;
    public static List<GameObject> nextPlanets;
    public static GameObject currentPlanet;

    public static bool loadData = false;
}
