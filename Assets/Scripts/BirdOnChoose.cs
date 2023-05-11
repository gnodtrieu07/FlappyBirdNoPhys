using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdOnChoose : MonoBehaviour
{
    public GameObject bird1;
    public GameObject bird2;
    public GameObject bird3;

    private int birdChoose;

    // Start is called before the first frame update
    void Start()
    {
        bird1.SetActive(true);
        bird2.SetActive(false);
        bird3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (birdChoose == 1)
        {
            bird1.SetActive(true);
            bird2.SetActive(false);
            bird3.SetActive(false);
        }
        else if (birdChoose == 2)
        {
            bird1.SetActive(false);
            bird2.SetActive(true);
            bird3.SetActive(false);
        }
        else if (birdChoose == 3)
        {
            bird1.SetActive(false);
            bird2.SetActive(false);
            bird3.SetActive(true);
        }

    }
}
