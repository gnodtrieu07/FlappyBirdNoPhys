using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TextMeshProUGUI presentScore;
    [SerializeField] TextMeshProUGUI bestScore;
    //private BirdType selectedBirdType = BirdType.Yellow;
    [SerializeField] YellowBird yellowBird;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;


        if( yellowBird.index > PlayerPrefs.GetInt("Best"))
        {
            PlayerPrefs.SetInt("Best", yellowBird.index);
        }
        
        presentScore.text = yellowBird.index.ToString();
        bestScore.text = PlayerPrefs.GetInt("Best").ToString();

    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ChooseBird(int index)
    {
        PlayerPrefs.SetInt("Option", index);
    }
}
