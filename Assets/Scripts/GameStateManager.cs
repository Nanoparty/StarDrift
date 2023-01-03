using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlanetData;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager gsm;

    public List<PlanetData> planetData;

    private void Awake()
    {
        if (gsm == null)
        {
            gsm = this;
        }
        else if (gsm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }

    private void GeneratePlanetNodes()
    {
        for(int i = 0; i < 9; i++)
        {
            System.Array values = System.Enum.GetValues(typeof(PlanetType));
            PlanetType type = (PlanetType)values.GetValue(Random.Range(0, values.Length));
            planetData.Add(new PlanetData(i, type));
        }
    }
}
