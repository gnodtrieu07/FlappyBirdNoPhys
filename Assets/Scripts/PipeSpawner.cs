using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float radius;
    private float timer = 0;
    [SerializeField] float maxTime = 1;
    [SerializeField] GameObject pipe1Prefab;
    [SerializeField] float verticalY = 0;
    public float pipeOffset;
    public float pipeHeight;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private int poolSize = 3;
    private List<GameObject> pipes;
    private int currentPipeIndex = 0;
    private float lastSpawnTime;

    void Start()
    {
        /*        GameObject newSpawn = Instantiate(pipe1Prefab);
                newSpawn.transform.position = transform.position + new Vector3(0, Random.Range(- verticalY, verticalY), 0);*/
        pipes = new List<GameObject>();

        // Khởi tạo pool các ống
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipe1Prefab);
            pipe.SetActive(false);
            pipes.Add(pipe);
        }

        // Lấy vị trí của ống đầu tiên và khởi tạo pool 2 ống tiếp theo
        Vector3 startPos = transform.position;
        for (int i = 0; i < 2; i++)
        {
            GameObject pipe = GetNextPipe();
            pipe.transform.position = startPos;
            startPos.x += pipe.GetComponent<PipeMove>().pipeWidth;
            pipe.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*        if(timer > maxTime)
                {
                    GameObject newSpawn = Instantiate(pipe1Prefab);
                    //Random vị trí tọa độ Y khi spawn pipe mới,
                    //vị trí hiện tại của bird + tạo ra vị trí ngẫu nhiên của ống.
                    newSpawn.transform.position = transform.position + new Vector3(0, Random.Range(- verticalY, verticalY), 0);
                    Destroy(newSpawn, 15);
                    //Đặt lại timer để chuẩn bị tạo ống mới lần tiếp theo
                    timer = 0;
                }
                timer += Time.deltaTime;*/

        if (Time.time - lastSpawnTime > spawnInterval)
        {
            GameObject pipe = GetNextPipe();

            // Lấy vị trí của ống cuối cùng và đặt ống mới vào vị trí đó
            Vector3 lastPipePos = pipes[currentPipeIndex].transform.position;
            pipe.transform.position = new Vector3(lastPipePos.x + pipe.GetComponent<PipeMove>().pipeWidth, 0, 0);

            // Đánh dấu ống mới là đang active và cập nhật currentPipeIndex
            pipe.SetActive(true);
            currentPipeIndex = (currentPipeIndex + 1) % pipes.Count;

            lastSpawnTime = Time.time;
        }
    }

    private GameObject GetNextPipe()
    {
        foreach (GameObject pipe in pipes)
        {
            if (!pipe.activeInHierarchy)
            {
                return pipe;
            }
        }

        // Nếu không có ống nào trong pool thì tạo thêm ống mới
        GameObject newPipe = Instantiate(pipe1Prefab);
        newPipe.SetActive(false);
        pipes.Add(newPipe);

        return newPipe;
    }
}
