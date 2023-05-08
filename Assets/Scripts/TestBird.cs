using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBird : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 3f;
    public float pipeGap = 5f;
    public float pipeSpeed = 2f;
    public float destroyXPos = -10f;

    private float lastSpawnTime = 0f;
    private List<GameObject> pipes = new List<GameObject>();
    private int score = 0;
    private bool gameOver = false;

    public Transform playerTransform;
    public float playerFlapForce = 5f;
    public float playerGravity = 10f;
    public float playerMaxVelocity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && Time.time - lastSpawnTime > spawnRate)
        {
            lastSpawnTime = Time.time;
            SpawnPipe();
        }

        for (int i = 0; i < pipes.Count; i++)
        {
            GameObject pipe = pipes[i];
            pipe.transform.position += Vector3.left * pipeSpeed * Time.deltaTime;

            if (pipe.transform.position.x < destroyXPos)
            {
                Destroy(pipe);
                pipes.RemoveAt(i);
                i--;
            }
            else if (!gameOver && pipe.transform.position.x < playerTransform.position.x &&
                pipe.transform.position.x + pipeGap > playerTransform.position.x)
            {
                // bird is inside the gap
                if (playerTransform.position.y > pipe.transform.position.y + 1f &&
                    playerTransform.position.y < pipe.transform.position.y + pipeGap - 1f)
                {
                    // bird passed through the gap, increase score
                    score++;
                    Debug.Log("Score: " + score);
                }
                else
                {
                    // bird hit the pipe, game over
                    Debug.Log("Game Over");
                    gameOver = true;
                }
            }
        }

  /*      if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // apply flap force
                playerTransform.GetComponent<Rigidbody2D>().velocity = Vector2.up * playerFlapForce;
            }

            // apply gravity
            playerTransform.position += Vector3.down * playerGravity * Time.deltaTime;

            // limit velocity
            if (playerTransform.GetComponent<Rigidbody2D>().velocity.y > playerMaxVelocity)
            {
                playerTransform.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    playerTransform.GetComponent<Rigidbody2D>().velocity.x, playerMaxVelocity);
            }
        }*/
    }

    void SpawnPipe()
    {
        float yPos = Random.Range(-3f, 3f);
        GameObject pipe = Instantiate(pipePrefab, new Vector3(10f, yPos, 0f), Quaternion.identity);
        pipes.Add(pipe);
    }
}
