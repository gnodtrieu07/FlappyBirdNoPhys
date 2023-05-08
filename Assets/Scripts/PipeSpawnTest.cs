using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnTest : MonoBehaviour
{
    public GameObject pipePrefab;
    public int numberOfPipes = 4;
    public float distanceBetweenPipes = 15f;
    public float pipeWidth = 2f;
    public float spawnXPosition = 15f;
    public float minYPosition = -4f;
    public float maxYPosition = 5f;

    private GameObject[] pipes;
    private int currentIndex = 0;

    void Start()
    {
        pipes = new GameObject[numberOfPipes];

        // Spawn initial pipes
        for (int i = 0; i < 3; i+=1)
        {
            //SpawnPipe(i);
            Vector2 position = new Vector2(i*10+7, Random.Range(minYPosition, maxYPosition));
            Quaternion rotation = Quaternion.identity;
            GameObject pipe = Instantiate(pipePrefab, position, rotation);
            pipes[i] = pipe;
        }
    }

    void Update()
    {
        // Check nếu ống đó rời khỏi tầm nhìn của màn hình
        if (pipes[currentIndex].transform.position.x < -spawnXPosition)
        {
            //Di chuyển ống đó đến cuối mảng ống
            //di chuyển ống đang xét đến vị trí tiếp theo trong mảng ống bằng cách sử dụng GetNextPosition()
            pipes[currentIndex].transform.position = GetNextPosition();

            //Tăng chỉ số của ống hiện tại lên 1
            //tăng chỉ số của ống hiện tại lên 1 + sử dụng phép chia lấy dư để đảm bảo rằng chỉ số sẽ luôn nằm trong phạm vi của mảng ống cho sẵn
            currentIndex = (currentIndex + 1) % numberOfPipes;
        }


    }

    //Tạo mới một đối tượng ống và đặt nó vào vị trí tiếp theo trong mảng pipes
    private void SpawnPipe(int index)
    {
        Vector3 position = GetNextPosition();
        //Gán không xoay cho ống
        Quaternion rotation = Quaternion.identity;
        //tạo mới một đối tượng ống prefab pipe với vị trí và hướng xoay được tính bằng hàm GNP
        //các ống này được lưu trữ trong mảng pipes[] với chỉ số index
        pipes[index] = Instantiate(pipePrefab, position, rotation);
        pipes[index].GetComponentInChildren<PipeMove>().SetWidth(pipeWidth);
    }

    //Ống tiếp theo
    private Vector3 GetNextPosition()
    {
        //Random.Range() để lấy một giá trị ngẫu nhiên
        float yPosition = Random.Range(minYPosition, maxYPosition);
        //Tính toán giá trị tọa độ x cho ống tiếp theo.
        float xPosition;
        // Check xem nếu là ống đầu tiên (cI = 0) => giá trị x sẽ được đặt bằng spawnXPosition
        if (currentIndex == 0)
        {
            xPosition = spawnXPosition;
        }
        //nếu không thì giá trị x sẽ được tính bằng tọa độ x của ống trước đó cộng với khoảng cách giữa các ống 
        else
        {
            xPosition = pipes[currentIndex - 1].transform.position.x + distanceBetweenPipes;
        }
        //Trả về vector3 mới với x và y đã đc tính toán
        return new Vector3(xPosition, yPosition, 0);
    }
}