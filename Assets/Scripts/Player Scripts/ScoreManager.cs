using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    private const string fileName = "score.txt";
    private int score;
    public TextMeshProUGUI scoreDisplay;
    private void Start()
    {
        // Retrieve the score when the game starts
        LoadScore();
       
    }
    private void Update()
    {
        SaveScore();
    }
    //private void Update()
    //{
    //    // Increase the score by 1 for testing purposes
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        score++;
    //        Debug.Log("Score Increased!");
    //    }
    //}

    public void IncreaseScore()
    {
        scoreDisplay.text = score.ToString();
        score++;
    }

    private void OnApplicationQuit()
    {
        // Save the score when the application is closed
        //SaveScore();
        //Debug.Log("Score Saved: " + score);
    }
    private void SaveScore()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        string scoreString = score.ToString();
        File.WriteAllText(filePath, scoreString);
    }

    private void LoadScore()
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(filePath))
        {
            string scoreString = File.ReadAllText(filePath);
            int.TryParse(scoreString, out score);
        }
        else
        {
            score = 0;
        }
    }
}
