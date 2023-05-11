using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] GameObject gameOverUI;

    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
/*        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore;
        }*/
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

  
}
