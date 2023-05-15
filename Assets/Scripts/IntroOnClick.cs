using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroOnClick : MonoBehaviour
{
    public GameObject startPanel; // Panel cần ẩn đi khi bắt đầu trò chơi

    private void Start()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
    }

    private void Update()
    {
        // Kiểm tra xem người chơi đã nhấn chuột hay chưa
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Ẩn panel và bắt đầu trò chơi
            startPanel.SetActive(false);
            StartGame();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }
}
