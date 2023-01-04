using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static GameObject PlanetPrefab;
    public static int numEnemies;

    public static List<GameObject> planets;
    public static List<int> visitedPlanets;
    public static List<int> nextPlanets;
    public static int currentPlanet = -1;

    public static bool loadData = false;

    public static List<PlanetData> planetData;

    public static long seed;

    public static long sessionTime = 100;
    public static int enemiesKilled = 11;
    public static int damageTaken = 5;
    public static int damageDealt = 20;
    public static int suppliesCollected = 7;
    public static int upgradesCollected = 2;
}
