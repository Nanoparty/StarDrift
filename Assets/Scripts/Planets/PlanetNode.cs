using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static PlanetData;

public class PlanetNode : MonoBehaviour
{
    [SerializeField] private List<GameObject> NextPlanets;
    [SerializeField] private GameObject PlanetInfoPrefab;
    [SerializeField] private GameObject InfoParent;
    [SerializeField] private bool Boss;

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

        TMP_Text text = GetComponentInChildren<TMP_Text>();
        if (Boss)
        {
            text.SetText("Boss");
        }
        else
        {
            text.SetText(planetData.reward);
        }
        
    }

    private void PlanetClick()
    {
        Debug.Log("Planet Info");
        infoPanel = Instantiate(PlanetInfoPrefab, Vector3.zero, Quaternion.identity);
        infoPanel.transform.parent = InfoParent.transform;
        infoPanel.transform.position = Vector3.zero;
        infoPanel.transform.localPosition = Vector3.zero;

        Image planetImage = infoPanel.transform.GetChild(1).gameObject.GetComponent<Image>();
        TMP_Text planetName = infoPanel.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
        TMP_Text environment = infoPanel.transform.GetChild(3).gameObject.GetComponent<TMP_Text>();
        TMP_Text danger = infoPanel.transform.GetChild(4).gameObject.GetComponent<TMP_Text>();
        TMP_Text reward = infoPanel.transform.GetChild(5).gameObject.GetComponent<TMP_Text>();

        planetImage.sprite = mapManager.GetPlanetSprite(planetData.type);
        planetName.SetText(planetData.planetName);
        environment.SetText("Environment:\n" + planetData.environment);
        danger.SetText("Danger Level:\n" + planetData.difficulty);
        reward.SetText("Planet Resources:\n" + planetData.detailReward);

        if (Boss)
        {
            danger.SetText("Danger Level:\nExtreme");
            reward.SetText("Planet Resources:\n?????");
        }

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
        Data.numEnemies = planetData.numEnemies;
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
