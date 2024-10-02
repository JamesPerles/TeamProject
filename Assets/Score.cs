using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI display if you want to show the score on the screen

public class ScoreManager : MonoBehaviour
{
   public int score = 0;  // Player's score
    public Text scoreText; // Reference to the UI text displaying the score

     //Call this method to increase the score when an enemy is killed
  / public void AddScore(int points)
    {
       score += points;  // Add points to the score
       UpdateScoreText(); // Update the UI (if using)
    }

    // Update the UI text to display the score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}