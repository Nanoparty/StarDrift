using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text shipsText;
    [SerializeField] private TMP_Text damageDealtText;
    [SerializeField] private TMP_Text damageTakenText;
    [SerializeField] private TMP_Text suppliesText;
    [SerializeField] private TMP_Text upgradesText;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private int shipsMultiplier = 5;
    [SerializeField] private int damageDealtMultiplier = 1;
    [SerializeField] private int damageTakenMultiplier = -1;
    [SerializeField] private int suppliesMultiplier = 1;
    [SerializeField] private int upgradesMultiplier = 5;

    [SerializeField] private Button Exit;

    private void Start()
    {
        int score = 0;

        int shipScore = Data.enemiesKilled * shipsMultiplier;
        int dealtScore = Data.damageDealt * damageDealtMultiplier;
        int takenScore = Data.damageTaken * damageTakenMultiplier;
        int suppliesScore = Data.suppliesCollected * suppliesMultiplier;
        int upgradesScore = Data.upgradesCollected * upgradesMultiplier;

        score += shipScore;
        score += dealtScore;
        score += takenScore;
        score += suppliesScore;
        score += upgradesScore;

        int minutes = (int)(Data.sessionTime / 60);
        int seconds = (int)(Data.sessionTime % 60);

        timeText.SetText(minutes + " min " + seconds + " sec");
        shipsText.SetText(Data.enemiesKilled + " * " + shipsMultiplier + " = " + shipScore);
        damageDealtText.SetText(Data.damageDealt + " * " + damageDealtMultiplier + " = " + dealtScore);
        damageTakenText.SetText(Data.damageTaken + " * " + damageTakenMultiplier+ " = " + takenScore);
        suppliesText.SetText(Data.suppliesCollected + " * " + suppliesMultiplier + " = " + suppliesScore);
        upgradesText.SetText(Data.upgradesCollected + " * " + upgradesMultiplier + " = " + upgradesScore);

        scoreText.SetText(score.ToString());

        Exit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        });
    }
}
