using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnTest2 : MonoBehaviour
{
    public float speed = 2f;
    public float pipeWidth = 1f;
    public float distanceBetweenPipes = 4f;
    public float spawnXPosition = 10f;
    public float minYPosition = -4f;
    public float maxYPosition = 5f;

    private GameObject[] pipes;
    private int numberOfPipes = 4;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        pipes = new GameObject[numberOfPipes];

        for (int i = 0; i < numberOfPipes; i++)
        {
            SpawnPipe(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the pipes to the left
        for (int i = 0; i < numberOfPipes; i++)
        {
            pipes[i].transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Check if a pipe has gone offscreen
        if (pipes[currentIndex].transform.position.x < -spawnXPosition)
        {
            // Move the pipe to the end of the array
            pipes[currentIndex].transform.position = GetNextPosition();

            // Increment the current index
            currentIndex = (currentIndex + 1) % numberOfPipes;
        }
    }

    private void SpawnPipe(int index)
    {
        Vector3 position = GetNextPosition();
        Quaternion rotation = Quaternion.identity;
        GameObject pipe = new GameObject("Pipe");
        pipe.transform.position = position;
        pipe.transform.rotation = rotation;

        // Add a pipe top
        GameObject pipeTop = new GameObject("Top");
        pipeTop.transform.parent = pipe.transform;
        pipeTop.transform.localPosition = new Vector3(0, pipeWidth / 2, 0);
        SpriteRenderer pipeTopSprite = pipeTop.AddComponent<SpriteRenderer>();
        pipeTopSprite.sprite = Resources.Load<Sprite>("Sprites/top");

        // Add a pipe bottom
        GameObject pipeBottom = new GameObject("Bottom");
        pipeBottom.transform.parent = pipe.transform;
        pipeBottom.transform.localPosition = new Vector3(0, -pipeWidth / 2, 0);
        SpriteRenderer pipeBottomSprite = pipeBottom.AddComponent<SpriteRenderer>();
        pipeBottomSprite.sprite = Resources.Load<Sprite>("Sprites/bottom");

        pipes[index] = pipe;
    }

    private Vector3 GetNextPosition()
    {
        float yPosition = Random.Range(minYPosition, maxYPosition);
        float xPosition;

        if (currentIndex == 0)
        {
            xPosition = spawnXPosition;
        }
        else
        {
            xPosition = pipes[currentIndex - 1].transform.position.x + distanceBetweenPipes;
        }

        return new Vector3(xPosition, yPosition, 0);
    }

    public float GetPipeWidth()
    {
        return pipeWidth;
    }

    public GameObject GetCurrentPipe()
    {
        return pipes[currentIndex];
    }

    public GameObject GetNextPipe()
    {
        return pipes[(currentIndex + 1) % numberOfPipes];
    }
}
