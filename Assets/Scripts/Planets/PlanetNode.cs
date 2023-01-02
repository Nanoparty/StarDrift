using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetNode : MonoBehaviour
{
    [SerializeField] private GameObject PlanetPrefab;
    [SerializeField] private List<GameObject> NextPlanets;
    [SerializeField] private GameObject PlanetInfoPrefab;
    [SerializeField] private GameObject InfoParent;
    [SerializeField] private int numEnemies;

    private GameObject infoPanel;
    private Clickable clickable;
    private bool infoOpen = false;
    private MapManager mapManager;
    private string status = "neutral";

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void Create()
    {
        numEnemies = 5;

        PlanetPrefab = PlanetData.pd.GetRandomPlanet();
        GameObject planet = Instantiate(PlanetPrefab, transform.position, Quaternion.identity);
        planet.transform.parent = transform;
        planet.transform.localScale = Vector3.one;
        mapManager = GameObject.Find("MapManager").GetComponent<MapManager>();
    }

    List<GameObject> GetNextPlanet()
    {
        return NextPlanets;
    }

    private void PlanetClick()
    {
        Debug.Log("Planet Info");
        infoPanel = Instantiate(PlanetInfoPrefab, Vector3.zero, Quaternion.identity);
        infoPanel.transform.parent = InfoParent.transform;
        infoPanel.transform.position = Vector3.zero;
        infoPanel.transform.localPosition = Vector3.zero;

        if (mapManager.IsNext(gameObject))
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
        mapManager.SetCurrentPlanet(this);

        Data.PlanetPrefab = PlanetPrefab;
        Data.numEnemies = numEnemies;

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

    public void SetStatus(string s)
    {
        status = s;
    }

    public string GetStatus()
    {
        return status;
    }
}
