using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance = null;

    private int score;

    [SerializeField] TextMeshProUGUI scoreText;

    public int Score { get { return score; } }

    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        UpdateTextGUI();
    }

    public void AddToScore(int amount)
    {
        score += amount;
        UpdateTextGUI();
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void UpdateTextGUI()
    {
        scoreText.text = $"{score:D5}";
    }
}
