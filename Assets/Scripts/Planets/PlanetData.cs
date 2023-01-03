using System;
using UnityEngine;

public class PlanetData
{
    public int id;
    public PlanetType type;
    public string status;

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
    }

}
