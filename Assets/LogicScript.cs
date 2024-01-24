using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
   public int playerScore;
   public Text scoreText;
   public Text highScoreText;
   public GameObject gameOverScreen;

   public void Start()
   {
      highScoreText.text = DataStore.HighScore.ToString();
   }

   [ContextMenu("Increase Score")]
   public void addScore(int scoreToAdd)
   {
      playerScore += 1;
      scoreText.text = playerScore.ToString();
      if (playerScore > DataStore.HighScore)
      {
         DataStore.HighScore = playerScore;
         highScoreText.text = DataStore.HighScore.ToString();
      }
   }

   public void restartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void gameOver()
   {
      gameOverScreen.SetActive(true);
      if (playerScore > DataStore.HighScore)
      {
         DataStore.HighScore = playerScore;
         highScoreText.text = DataStore.HighScore.ToString();
      }
   }
}
