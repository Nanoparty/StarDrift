using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlanetData;

public class NodeData 
{
    public PlanetType type;
    public int numEnemies;
    public string planetName;
    public string reward;
    public string status;

    public NodeData(PlanetType type, int num, string name, string status)
    {
        this.type = type;
        this.numEnemies = num;
        this.planetName = name;
        this.status = status;
    }
}
