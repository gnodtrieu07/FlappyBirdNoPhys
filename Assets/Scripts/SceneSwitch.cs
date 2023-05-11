using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    private static int birdChoose;
    public static SceneSwitch instance;

    private void Awake()
    {
        instance = this;
    }
    public void Yellow()
    {
        birdChoose = 1;
        SceneManager.LoadScene(1);
    }
    public void Red()
    {
        birdChoose = 2;
        SceneManager.LoadScene(1);
    }
    public void Blue()
    {
        birdChoose = 3;
        SceneManager.LoadScene(1);
    }
    public static int GetBird()
    {
        return birdChoose;
    }
}
