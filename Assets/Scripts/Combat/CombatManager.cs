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

    [SerializeField] private bool isBoss;

    private GameObject rewards;

    private void Start()
    {
        
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
                rewards.transform.Find("Buttons").transform.Find("Map").GetComponent<Button>()
                    .onClick.AddListener(MapListener);
            }
            
        }
    }

    private void MapListener()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
}
