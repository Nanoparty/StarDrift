using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HangarManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameObject nameTaken;
    [SerializeField] private GameObject nameMissing;
    [SerializeField] private Button Begin;

    private void Start()
    {
        nameTaken.SetActive(false);
        nameMissing.SetActive(false);

        Begin.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        nameMissing.SetActive(false);
        nameTaken.SetActive(false);

        string playerName = input.text;

        if (playerName == "")
        {
            nameMissing.SetActive(true);
            return;
        }

        List<string> pastNames = Data.pastNames ?? new List<string>();
        if (pastNames.Contains(playerName))
        {
            nameTaken.SetActive(true);
            return;
        }

        Data.playerName = playerName;
        pastNames.Add(playerName);
        Data.pastNames = pastNames;

        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
}
