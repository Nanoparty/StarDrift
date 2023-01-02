using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform AsteroidTransform;
    [SerializeField] private Transform CometTransform;
    [SerializeField] private Transform NebulaTransform;
    [SerializeField] private Transform GalaxyTransform;
    [SerializeField] private Transform StationTransform;
    [SerializeField] private Transform PlanetTransform;
    [SerializeField] private Transform QuasarTransform;
    [SerializeField] private Transform StarClusterTransform;
    [SerializeField] private Transform EnemyTransform;
    [SerializeField] private Transform BlackholeTransform;
    [SerializeField] private Transform TechTransform;

    [SerializeField] private List<GameObject> Asteroids;
    [SerializeField] private List<GameObject> Nebulas;
    [SerializeField] private List<GameObject> Galaxies;
    [SerializeField] private List<GameObject> Stations;
    [SerializeField] private List<GameObject> Quasars;
    [SerializeField] private List<GameObject> StarClusters;
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private List<GameObject> Blackholes;
    [SerializeField] private List<GameObject> Comets;
    [SerializeField] private List<GameObject> Tech;

    private void Start()
    {
        SpawnPlanet();
        SpawnEnemies();
        SpawnAsteroids();
        SpawnNebulas();
        SpawnGalaxies();
        SpawnQuasars();
        SpawnStarClusters();
        SpawnBlackholes();
        SpawnComets();
        SpawnTech();
        SpawnStation();
    }

    private void SpawnPlanet()
    {
        GameObject planetPrefab = Data.PlanetPrefab ?? PlanetData.pd.Terra_1;
        GameObject planet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
        planet.transform.parent = PlanetTransform;
        planet.transform.localPosition = Vector3.zero;
        planet.transform.localScale = new Vector3(2, 2, 2);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < Data.numEnemies; i++)
        {
            GameObject enemy = Instantiate(RandomObject(Enemies), Vector3.zero, Quaternion.identity);
            enemy.transform.parent = EnemyTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            enemy.transform.localPosition = new Vector3(x, y, 0);
        }

        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SpawnArrows();
    }

    private void SpawnAsteroids()
    {
        int num = Random.Range(5, 10);
        for (int i = 0; i < num; i++)
        {
            GameObject asteroid = Instantiate(RandomObject(Asteroids), Vector3.zero, Quaternion.identity);
            asteroid.transform.parent = AsteroidTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            asteroid.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnNebulas()
    {
        int num = Random.Range(5, 10);
        for (int i = 0; i < num; i++)
        {
            GameObject nebula = Instantiate(RandomObject(Nebulas), Vector3.zero, Quaternion.identity);
            nebula.transform.parent = NebulaTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            nebula.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnGalaxies()
    {
        int num = Random.Range(3, 5);
        for (int i = 0; i < num; i++)
        {
            GameObject galaxy = Instantiate(RandomObject(Galaxies), Vector3.zero, Quaternion.identity);
            galaxy.transform.parent = GalaxyTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            galaxy.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnQuasars()
    {
        int num = Random.Range(3, 5);
        for (int i = 0; i < num; i++)
        {
            GameObject quasar = Instantiate(RandomObject(Quasars), Vector3.zero, Quaternion.identity);
            quasar.transform.parent = QuasarTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            quasar.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnStarClusters()
    {
        int num = Random.Range(5, 10);
        for (int i = 0; i < num; i++)
        {
            GameObject starcluster = Instantiate(RandomObject(StarClusters), Vector3.zero, Quaternion.identity);
            starcluster.transform.parent = StarClusterTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            starcluster.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnBlackholes()
    {
        int num = Random.Range(1, 2);
        for (int i = 0; i < num; i++)
        {
            GameObject blackhole = Instantiate(RandomObject(Blackholes), Vector3.zero, Quaternion.identity);
            blackhole.transform.parent = BlackholeTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            blackhole.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnComets()
    {
        int num = Random.Range(5, 10);
        for (int i = 0; i < num; i++)
        {
            GameObject comet = Instantiate(RandomObject(Comets), Vector3.zero, Quaternion.identity);
            comet.transform.parent = CometTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            comet.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnTech()
    {
        int num = Random.Range(0,1);
        for (int i = 0; i < num; i++)
        {
            GameObject tech = Instantiate(RandomObject(Tech), Vector3.zero, Quaternion.identity);
            tech.transform.parent = TechTransform;
            float x = Random.Range(-20f, 20f);
            float y = Random.Range(-20f, 20f);
            tech.transform.localPosition = new Vector3(x, y, 0);
        }
    }

    private void SpawnStation()
    {
        int num = Random.Range(1, 1);
        for (int i = 0; i < num; i++)
        {
            GameObject station = Instantiate(RandomObject(Stations), Vector3.zero, Quaternion.identity);
            station.transform.parent = StationTransform;
            station.transform.localPosition = Vector3.zero;
        }
    }

    private GameObject RandomObject(List<GameObject> objects)
    {
        return objects[Random.Range(0, objects.Count)];
    }
}
