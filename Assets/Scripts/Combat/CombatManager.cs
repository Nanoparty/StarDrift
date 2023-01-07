using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Enemies;
    [SerializeField] private GameObject RewardCard;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Alert;

    [SerializeField] private bool isBoss;
    public bool isStarted;

    private GameObject rewards;

    private void Start()
    {
        if (isBoss)
        {

        }
        else
        {
            GameObject alert = Instantiate(Alert, Vector3.zero, Quaternion.identity);
            alert.transform.parent = UI.transform;
            alert.transform.localPosition = Vector3.zero;
            alert.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                isStarted = true;
                Destroy(alert);
            });
        }
    }

    private void Update()
    {
        if (isBoss)
        {
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("All Enemies Dead");
            if (rewards == null)
            {
                rewards = Instantiate(RewardCard, Vector3.zero, Quaternion.identity);
                rewards.transform.parent = UI.transform;
                rewards.transform.localPosition = Vector3.zero;
                rewards.GetComponentInChildren<Button>().onClick.AddListener(MapListener);
            }
            
        }
    }

    private void MapListener()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
}
