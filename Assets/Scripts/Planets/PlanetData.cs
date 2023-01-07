using System;
using UnityEngine;

public class PlanetData
{
    public int id;
    public PlanetType type;
    public string planetName;
    public string status;
    public string reward;
    public string detailReward;
    public string difficulty;
    public int numEnemies;
    public string environment;
    public bool boss;

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


    public PlanetData(int id, PlanetType type)
    {
        this.id = id;
        this.type = type;
        this.status = "neutral";
        this.planetName = "Terra XIV";
        this.environment = GetPlanetEnvironment(type);

        GenerateEnemies();
        GenerateReward();
    }

    private void GenerateReward()
    {
        int coin = UnityEngine.Random.Range(0, 3);

        if (coin == 0)
        {
            reward = "Health";
            detailReward = "Health Increase";
        }
        else if (coin == 1)
        {
            reward = "Damage";
            detailReward = "Damage Increase";
        }
        else if (coin == 2)
        {
            reward = "Speed";
            reward = "Speed Increase";
        }
    }

    private void GenerateEnemies()
    {
        int coin = UnityEngine.Random.Range(0, 3);

        if (coin == 0)
        {
            difficulty = "Low";
            numEnemies = 5;
        }
        if (coin == 1)
        {
            difficulty = "Moderate";
            numEnemies = 10;
        }
        if (coin == 2)
        {
            difficulty = "High";
            numEnemies = 15;
        }
        
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
