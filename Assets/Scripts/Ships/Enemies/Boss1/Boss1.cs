using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private GameObject VictoryWindow;
    [SerializeField] private Transform VictoryTransform;

    private GameObject victory;

    private void Update()
    {
        HandleDeath();
    }

    private void HandleDeath()
    {
        if (health <= 0 && victory == null)
        {
            Debug.Log("Boss Dead");
            victory = Instantiate(VictoryWindow, Vector3.zero, Quaternion.identity);
            victory.transform.parent = VictoryTransform;
            victory.transform.localPosition = Vector3.zero;
            victory.transform.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Final", LoadSceneMode.Single);
            });
        }
    }

    public void TakeDamage(float damage)
    {
        health -= (int)damage;
    }
}
