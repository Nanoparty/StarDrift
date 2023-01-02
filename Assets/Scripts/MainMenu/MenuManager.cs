using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button New;
    [SerializeField] private Button Load;
    [SerializeField] private Button Hangar;
    [SerializeField] private Button Options;
    [SerializeField] private Button Exit;

    private void Start()
    {
        New.onClick.AddListener(NewListener);
        Load.onClick.AddListener(LoadListener);
        Hangar.onClick.AddListener(HangarListener);
        Options.onClick.AddListener(OptionsListener);
        Exit.onClick.AddListener(ExitListener);
    }

    private void NewListener()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }

    private void LoadListener()
    {

    }

    private void HangarListener()
    {

    }

    private void OptionsListener()
    {

    }

    private void ExitListener()
    {
        Application.Quit();
    }
}
