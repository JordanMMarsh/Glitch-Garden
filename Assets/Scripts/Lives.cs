using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour {

    [SerializeField] int totalLives = 100;
    TextMeshProUGUI livesText;

    private void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        var difficulty = PlayerPrefsController.GetDifficulty();
        switch (difficulty)
        {
            case 1:
                {
                    totalLives = 100;
                    break;
                }
            case 2:
                {
                    totalLives = 75;
                    break;
                }
            case 3:
                {
                    totalLives = 50;
                    break;
                }
            default:
                {
                    totalLives = 75;
                    break;
                }
        }
        UpdateLives();
    }

    public void LoseLives(int lives)
    {
        totalLives -= lives;
        UpdateLives();
        if (totalLives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
    }

    private void UpdateLives()
    {
        livesText.text = totalLives.ToString();
    }

}
