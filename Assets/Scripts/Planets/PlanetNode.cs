using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlanetData;

public class PlanetNode : MonoBehaviour
{
    [SerializeField] private List<GameObject> NextPlanets;
    [SerializeField] private GameObject PlanetInfoPrefab;
    [SerializeField] private GameObject InfoParent;

    public int id;
    public PlanetData planetData;

    private GameObject infoPanel;
    private bool infoOpen = false;
    private MapManager mapManager;

    private void Start()
    {
    }

    private void Update()
    {

    }

    public void Create()
    {
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();

        GameObject PlanetPrefab = mapManager.GetPlanetPrefab(planetData.type);
        GameObject planet = Instantiate(PlanetPrefab, transform.position, Quaternion.identity);
        planet.transform.parent = transform;
        planet.transform.localScale = Vector3.one;
        
    }

    private void PlanetClick()
    {
        Debug.Log("Planet Info");
        infoPanel = Instantiate(PlanetInfoPrefab, Vector3.zero, Quaternion.identity);
        infoPanel.transform.parent = InfoParent.transform;
        infoPanel.transform.position = Vector3.zero;
        infoPanel.transform.localPosition = Vector3.zero;

        if (mapManager.IsNext(id))
        {
            infoPanel.transform.Find("Buttons").transform.Find("Travel")
                .GetComponent<Button>().onClick.AddListener(TravelToPlanet);
        }
        else
        {
            infoPanel.transform.Find("Buttons").transform.Find("Travel")
                .gameObject.SetActive(false);

        }
        infoPanel.transform.Find("Buttons").transform.Find("Cancel")
            .GetComponent<Button>().onClick.AddListener(CloseInfo);
    }

    private void TravelToPlanet()
    {
        infoOpen = false;
        mapManager.InfoOpen = false;
        Destroy(infoPanel.gameObject);
        mapManager.SetCurrentPlanet(id);

        Data.PlanetPrefab = mapManager.GetPlanetPrefab(planetData.type);
        mapManager.SaveNodes();
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    private void CloseInfo()
    {
        infoOpen = false;
        mapManager.InfoOpen = false;
        Destroy(infoPanel.gameObject);
        Debug.Log("Cancel");
    }

    private void OnMouseDown()
    {
        if (!infoOpen && !mapManager.InfoOpen)
        {
            Debug.Log("Open Info");
            infoOpen = true;
            mapManager.InfoOpen = true;
            PlanetClick();
        }
    }

    public List<GameObject> GetNextPlanets()
    {
        return NextPlanets;
    }
}
