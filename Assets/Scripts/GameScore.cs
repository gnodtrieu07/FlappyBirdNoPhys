using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameScore : MonoBehaviour
{

    public static int score = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
