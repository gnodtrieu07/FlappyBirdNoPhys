using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore : MonoBehaviour
{

    public static int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
